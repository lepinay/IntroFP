open System.Net
open System

let fetchUrl callback url =        
    let req = WebRequest.Create(Uri(url)) 
    use resp = req.GetResponse() 
    use stream = resp.GetResponseStream() 
    use reader = new IO.StreamReader(stream) 
    callback reader url

let myCallback (reader:IO.StreamReader) url = 
    let html = reader.ReadToEnd()
    let html1000 = html.Substring(0,1000)
    printfn "Downloaded %s. First 1000 is %s" url html1000
    html  

fetchUrl myCallback "http://www.google.com"
fetchUrl myCallback "http://news.bbc.co.uk"

let myfetchUrl = fetchUrl myCallback 

myfetchUrl "http://www.google.com"
myfetchUrl "http://news.bbc.co.uk"

let sites = ["http://www.bing.com";
             "http://www.google.com";
             "http://www.yahoo.com"]

sites |> List.map myfetchUrl 


// Currying
let add a b c = a + b + c
add 1 2 3

(((add 1) 2)3)

let add1bc = add 1

let addd a = 
    fun b ->
        fun c -> a + b + c

// JS currying
//function add(a){
//    return function(b){
//        return function(c){
//            return a+b+c;
//        }
//    }
//}
//var add1bc = add(1);
