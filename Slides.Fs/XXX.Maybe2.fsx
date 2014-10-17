type Maybe<'T> = 
    |Some of 'T
    |Nothing
    member x.get defaultValue =
        match x with
        |Some(s) -> s
        |Nothing -> defaultValue


type MaybeBuilder() =
    member this.Bind(x,f) =
        match x with 
            | Some(curr) -> f curr
            | Nothing -> Nothing

    member this.Return(x) = Some(x)

let maybe = MaybeBuilder()

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


maybe {
   let p = {PersonalDetail=Nothing}
   let! detail = p.PersonalDetail
   let! pn = detail.PhoneNumber
   let! hn = pn.Home
   return hn.ToUpper()
}







