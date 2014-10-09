// Hello World
printfn "Hello world"

// Basic types
let myInt = 5
let myFloat = 3.14
let myString = "hello"   


// Lists
let twoToFive = [2;3;4;5]        
let oneToFive = 1 :: twoToFive   
let zeroToFive = [0;1] @ twoToFive   

// Functions
// The "let" keyword also defines a named function.
let square x = x * x          // Note that no parens are used.
square 3                      // Now run the function. Again, no parens.


// Charting in excel
#r "Microsoft.Office.Interop.Excel.dll"
open FSharp.Data
open Microsoft.Office.Interop.Excel
 
let data = WorldBankData.GetDataContext()
 
let app = new ApplicationClass(Visible = true)
let workbook = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet)
let worksheet = (workbook.Worksheets.[1] :?> Worksheet)
 
let titles = [| "Year"; "Values" |]
 
let getDataFrom indicator = 
    let years = Seq.map fst indicator
    let values = Seq.map snd indicator
    (Seq.map2(fun x y -> (x, y)) years values)
    |> Seq.map (fun (x, y) -> [|float(x); y|])
    |> array2D


// Charting using external lib
#r @"packages\FSharp.Data.2.0.15\lib\net40\FSharp.Data.dll"
#load @"packages/FSharp.Charting.0.90.7/FSharp.Charting.fsx"
open FSharp.Data
open FSharp.Charting
 
let data = WorldBankData.GetDataContext()
let murica = data.Countries.``United States``
let life = murica.Indicators.``Life expectancy at birth, total (years)``
Chart.Line(life,Name="Life Expectancy (All) United States")
     .WithYAxis(Min= 70.0, Title="Life Expectancy in Years")
     .WithXAxis(Title="Year")