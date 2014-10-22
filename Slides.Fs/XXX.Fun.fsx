// Explore .NET interactively
open System
DateTime.Now.ToString "yyyy-MM-dd hh:mm"
DateTime.Now.ToString "yyyy-MM-dd HH:mm" 

Environment.GetEnvironmentVariable "ProgramFiles" = 
    Environment.GetEnvironmentVariable "PROGRAMFILES"

// Forms
open System.Windows.Forms 
open System.Drawing

let form = new Form(Width= 400, Height = 300, Visible = true, Text = "Hello World") 
form.TopMost <- true
form.Click.Add (fun _ -> 
    form.Text <- sprintf "form clicked at %i" DateTime.Now.Ticks)
form.Show()

let panel = new FlowLayoutPanel()
form.Controls.Add(panel)
panel.Dock <- DockStyle.Fill
panel.WrapContents <- true 

let greenButton = new Button()
greenButton.Text <- "Make the background color green" 
greenButton.Click.Add (fun _-> form.BackColor <- Color.LightGreen)
panel.Controls.Add(greenButton) 

greenButton.AutoSize <- true

let yellowButton = new Button()
yellowButton.Text <- "Make me yellow" 
yellowButton.AutoSize <- true
yellowButton.Click.Add (fun _-> form.BackColor <- Color.Yellow)
panel.Controls.Add(yellowButton) 

panel.FlowDirection <- FlowDirection.TopDown

yellowButton.Dock <- DockStyle.Fill



#r @"..\packages\FSharp.Data.2.0.15\lib\net40\FSharp.Data.dll"
open FSharp.Data
// Explore Web Services
//#region secret key
let apiKey = "3266f4f3608a03d134d5dff59a3c1bf9"
//#endregion
Http.RequestString
  ( "http://api.themoviedb.org/3/search/movie", httpMethod = "GET",
    query   = [ "api_key", apiKey; "query", "batman" ],
    headers = [ "Accept", "application/json" ])

type MovieResult = JsonProvider<"""{"page":1,"results":[{"adult":false,"backdrop_path":"/2blmxp2pr4BhwQr74AdCfwgfMOb.jpg","id":268,"original_title":"Batman","release_date":"1989-06-22","poster_path":"/u782c0lom0YlLwSWX0X2o72OJDT.jpg","popularity":1.42,"title":"Batman","vote_average":6.6,"vote_count":536},{"adult":false,"backdrop_path":"/tVLnQf6AvWKz8yRpoOnfTu0kht4.jpg","id":186579,"original_title":"Batman Tech","release_date":"2008-07-20","poster_path":"/1k0ep5h934ddQKvfVQe4gY9NhGj.jpg","popularity":0.0125739148465572,"title":"Batman Tech","vote_average":0.0,"vote_count":0}],"total_pages":3,"total_results":60}""">
let res = 
    Http.RequestString
      ( "http://api.themoviedb.org/3/search/movie", httpMethod = "GET",
        query   = [ "api_key", apiKey; "query", "batman" ],
        headers = [ "Accept", "application/json" ])
    |> MovieResult.Parse


res.Results 
    |> Array.sortBy(fun r -> -r.VoteAverage) 
    |> Array.map(fun r -> (r.Title,r.VoteAverage,r.VoteCount))
let res2 = query {
    for r in res.Results do
    sortBy -r.VoteAverage
    select (r.Title,r.VoteAverage,r.VoteCount, r.PosterPath)
} 

let addImage label url = 
    let pb = new PictureBox()
    pb.ImageLocation <- "https://image.tmdb.org/t/p/w92/"+url
    let lbl = new Label()
    lbl.Text <- label
    panel.Controls.Add lbl
    panel.Controls.Add(pb)

for (title,vote,count,poster) in res2 do 
    addImage title poster

// Explore Data using type providers
open FSharp.Data
let data = FreebaseDataProvider<"AIzaSyDtLV0IJ2YiVF2oX7T5eMidGswiJxG4iR0">.GetDataContext()
let biology = data.``Science and Technology``.Biology
let computers = data.``Science and Technology``.Computers
let chemistry = data.``Science and Technology``.Chemistry
let astronomy = data.``Science and Technology``.Astronomy
let books = data.``Arts and Entertainment``.Books

/// Get the names of the US presidents
let presidents = 
    query { for e in data.Society.Government.``US Presidents`` do 
            select e.Name } 
    |> Seq.toList

/// Count the stars listed in the database
let numberOfStars = astronomy.Stars |> Seq.length

/// The name and distances of stars which have a distance recorded.
let someStarDistances = 
    query { for e in astronomy.Stars do 
            where e.Distance.HasValue
            select (e.Name, e.Distance) } 
      |> Seq.toList


let a = 1
a = 2

/// Get the stars in the database sorted by proximity to earth
let starsSortedByProximityToEarth = 
    query { for e in astronomy.Stars do 
            sortBy e.Distance.Value
            take 10
            select e } 
      |> Seq.toList

 /// Get some stars close to Earth
let getSomeCloseStars = 
    query { for e in astronomy.Stars do 
            where (e.Distance.Value < 4.011384e+18<_>)
            select e } 
      |> Seq.toList

let cyclones = 
    query {
        for x in data.Commons.Meteorology
          .``Tropical Cyclones`` do
        where x.``Highest winds``.HasValue
    }
    |> Seq.toList

#load @"../packages/FSharp.Charting.0.90.7/FSharp.Charting.fsx"
open FSharp.Charting
let cyclonesWithDamages =
     cyclones 
     |> List.filter (fun cy -> cy.Damages <> null )

Chart.Point([for cy in cyclonesWithDamages -> cy.Name
                                                , cy.Damages
                                                .Amount.Value / 1e9])
  .WithYAxis(Title="Damage (US$)")
  .WithXAxis(Title="Name")

Chart.Point([for cy in cyclonesWithDamages -> cy.``Highest winds``
                                                .Value, cy.Damages
                                                .Amount.Value / 1e9])
  .WithYAxis(Title="Damage (US$)")
  .WithXAxis(Title="Wind Speed")


let cyclonesWithFatalities =
    cyclones
    |> List.filter 
       (fun cy -> cy.``Total fatalities``.HasValue)

Chart.Point([for cy in cyclonesWithFatalities -> cy.``Highest winds``
                                                   .Value, cy
                                                   .``Total fatalities``
                                                   .Value])
let cyclonesWithFatalitiesRefined =
    cyclones
    |> List.filter 
       (fun cy -> cy.``Total fatalities``.HasValue &&
                              cy.Name <> "Cyclone Nargis")

Chart.Point([for cy in cyclonesWithFatalitiesRefined 
    -> 
        cy.``Highest winds``
           .Value, cy
           .``Total fatalities``
           .Value])

// WorldBank
let response = 
    Http.RequestString( "http://api.worldbank.org/country/cz/indicator/GC.DOD.TOTL.GD.ZS?format=json", httpMethod = "GET",
        headers = [ "Accept", "application/json" ])

type WorldBank = JsonProvider<"worldbank.json">
WorldBank
    .Parse(response).Array |> Seq.map(fun r->r.Country )


// Charting
[ (0.4, 1.2); (1., 4.3); (2.2, 10.5); (3.5, 12.); (4.0, 15.) ] |> Chart.Line

Chart.Combine([ Chart.Line [(2, 15); (1, 10)]
                Chart.Line [(2, 10); (1, 15)] ])

let datas = [[(20,40); (15,30); (2,20); (39,10)];[(40,10); (30,14); (20,14); (10,14)]] |> List.toSeq
datas |> Chart.StackedArea

Chart.Pie([("one", 33); ("two", 5); ("three", 74); ("four", 101)])
            .WithLegend()

Chart.Bar([("one", 33); ("two", 5); ("three", 74); ("four", 101)])
            .WithLegend()

Chart.Column([("one", 33); ("two", 5); ("three", 74); ("four", 101)])
            .WithLegend()

// example CSV, XML
// Hadoop, Odata (netflix), wsdl

    