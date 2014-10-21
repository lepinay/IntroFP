type MaybeBuilder() =
    member this.Bind(x,f) =
        if x <> null then f x
        else null

    member this.Return(x) = x

let maybe = MaybeBuilder()

[<AllowNullLiteralAttribute>]
type PhoneNumber() = 
     member val Home:string = null with get,set
     member val Work:string = null with get,set

[<AllowNullLiteralAttribute>]
type Detail() = 
     member val PhoneNumber: PhoneNumber = null with get,set
    
[<AllowNullLiteralAttribute>]
type Person() = 
     member val PersonalDetail : Detail = null with get,set
    
maybe {
   let p = Person()
   let! detail = p.PersonalDetail
   let! pn = detail.PhoneNumber
   let! hn = pn.Home
   return hn.ToUpper()
}







