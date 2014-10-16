let addingCalculator input = input + 1

let loggingCalculator innerCalculator input = 
   printfn "input is %A" input
   let result = innerCalculator input
   printfn "result is %A" result
   result

