type Address = {Street:string;City:string}
type Person = {FirstName:string; LastName:string; HomeAddress:Address}

printfn "%A" {FirstName="John";LastName="Connor";HomeAddress={Street="NA";City="Los Angeles"}} 


