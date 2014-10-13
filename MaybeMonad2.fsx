open System
open System.Collections.Generic

type Maybe =
    | Something of string
    | Nothing 

let bind f m = 
    match m with
        | Something(s) -> 
            if System.String.IsNullOrEmpty(s) then Nothing else Something(f(s))
        | Nothing -> Nothing

Something("bob")
|>bind(fun s -> "Hello " + s)
|>bind(fun hello -> hello + "!!!")

bind2 Something("bob") (fun s ->  bind2 "Hello " + s (fun t -> t + "!!!" )  )

Something("Bob")
|>bind(fun s -> "")
|>bind(fun hello -> hello + "!!!")


type Task<'T>(onSubscribe:('T->unit)->unit) =
    member x.Subscribe (f:'T->unit) =
        onSubscribe(f)

    static member Return t =
        new Task<'T>(fun s -> s(t))

    member x.Bind (f:'T->Task<'U>) =
        new Task<'U>( fun s -> x.Subscribe(fun t -> f(t).Subscribe(fun u -> s(u) )  ))
    

let fetchUrl url =
    new Task<string>(fun s -> 
        use c = new System.Net.WebClient()
        c.DownloadStringCompleted.Add(fun e -> s(e.Result) )
        c.DownloadStringAsync(url) ) 

(fetchUrl (Uri("http://www.google.com")))
    .Bind(fun s -> Task.Return(s.ToUpper()))
    .Bind(fun s -> s |> Seq.take 10 |> Task.Return)
    .Subscribe(fun s -> printfn "%A" s)

let bind (e:IEnumerable<'T>) (f:'T->IEnumerable<'T>) =
    let enumerator = e.GetEnumerator()
    while enumerator.MoveNext() do
        let enumerator2 = (f enumerator.Current).GetEnumerator()
        while enumerator2.MoveNext() do
            enumerator2.Current
    


