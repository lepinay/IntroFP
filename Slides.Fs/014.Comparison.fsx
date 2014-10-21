type Address = {Street:string;City:string}
type Person = {FirstName:string; LastName:string; HomeAddress:Address}

let john = {FirstName="John";LastName="Connor";HomeAddress={Street="NA";City="Los Angeles"}}
let johnClone = {FirstName="John";LastName="Connor";HomeAddress={Street="NA";City="New York"}}
let sarah = {FirstName="Sarah";LastName="Connor";HomeAddress={Street="NA";City="Los Angeles"}}
john > johnClone 

printfn "%A" {FirstName="John";LastName="Connor";HomeAddress={Street="NA";City="Los Angeles"}} 


