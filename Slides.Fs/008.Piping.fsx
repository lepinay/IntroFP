let square x = x * x

{ 1..100 }
|> Seq.map square
|> Seq.sum



