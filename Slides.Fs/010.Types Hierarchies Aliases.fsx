type Radius = int
type Width = int
type Height = int
type X=int
type Y=int

type Point = X*Y
type Shape =        // define a "union" of alternative structures
    | Circle of Radius 
    | Rectangle of Width * Height
    | Polygon of Point list

let draw shape =    // define a function "draw" with a shape param
  match shape with
  | Circle radius -> 
      printfn "The circle has a radius of %d" radius
  | Rectangle (height,width) -> 
      printfn "The rectangle is %d high by %d wide" height width
  | Polygon points -> 
      printfn "The polygon is made of these points %A" points
  | _ -> printfn "I don't recognize this shape"

let circle = Circle(10)
let rect = Rectangle(4,5)
let polygon = Polygon( [(1,1); (2,2); (3,3)])

[circle; rect; polygon;] |> List.iter draw