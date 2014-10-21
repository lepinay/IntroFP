type Address = {Street:string;City:string}
type Person = {FirstName:string; LastName:string; HomeAddress:Address}

let john = {FirstName="John";LastName="Connor";HomeAddress={Street="NA";City="Los Angeles"}} 
let johnClone = {FirstName="John";LastName="Connor";HomeAddress={Street="NA";City="Los Angeles"}} 
john = johnClone


