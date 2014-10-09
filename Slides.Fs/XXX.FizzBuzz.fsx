for c in [1..100] do
   match c%3,c%5 with
       | 0,0 -> printfn "FizzBuzz" 
       | 0,_ -> printfn "Fizz"
       | _,0 -> printfn "Buzz"
       | _ -> printfn "%d" c

