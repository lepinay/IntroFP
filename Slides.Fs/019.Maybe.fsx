let check (x, f)  =
    if x <> null then f x
    else null

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

let p = Person()
let upperPhone = 
    check(p.PersonalDetail, fun detail -> 
    check(detail.PhoneNumber, fun pn -> 
    check(pn.Home,fun hn -> hn.ToUpper())))









