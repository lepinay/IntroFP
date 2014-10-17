type Maybe<'T> = 
    |Some of 'T
    |Nothing

    member x.get defaultValue =
        match x with
        |Some(s) -> s
        |Nothing -> defaultValue

    
    member x.check f  =
        match x with
        | Some(a) ->
             f a
        | Nothing -> Nothing


type PhoneNumber = {
     Home:Maybe<string>
     Work:Maybe<string>
    }

type Detail = {
     PhoneNumber: Maybe<PhoneNumber>
    }

type Person = {
     PersonalDetail : Maybe<Detail>
    }



let p = {PersonalDetail=Nothing}

let upperPhone = 
    p.PersonalDetail.check(fun detail -> 
    detail.PhoneNumber.check(fun pn -> 
    pn.Home.check(fun hn -> 
    Some(hn.ToUpper())))).get("No Phone Number") 









