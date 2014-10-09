for c in [1..100] do
   match c%3,c%5 with
       | 0,0 ->  "FizzBuzz" 
       | 0,_ ->  "Fizz"
       | _,0 ->  "Buzz"
       | _ ->  c.ToString()
    |> printfn "%A"

