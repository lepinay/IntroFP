let add1 input = input + 1

let genericLogger anyFunc input = 
   printfn "input is %A" input   //log the input
   let result = anyFunc input    //evaluate the function
   printfn "result is %A" result //log the result
   result                        //return the result

let genericTimer anyFunc input = 
   let stopwatch = System.Diagnostics.Stopwatch()
   stopwatch.Start() 
   let result = anyFunc input  //evaluate the function
   printfn "elapsed ms is %A" stopwatch.ElapsedMilliseconds
   result
   
let add1WithLogging = genericLogger add1
let add1WithTimer = genericTimer add1WithLogging 

// test
add1WithTimer 3