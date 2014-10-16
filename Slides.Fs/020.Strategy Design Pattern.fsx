type Animal(noiseMakingStrategy) = 
   member this.MakeNoise = 
      noiseMakingStrategy() |> printfn "Making noise %s" 
   
let meowingStrategy() = "Meow"
let woofOrBarkStrategy() = 
    if (System.DateTime.Now.Second % 2 = 0) 
    then "Woof" else "Bark"


let cat = Animal(meowingStrategy)
cat.MakeNoise

let dog = Animal(woofOrBarkStrategy)
dog.MakeNoise
dog.MakeNoise  //try again a second later