open System
open System.Windows.Forms 
open System.Drawing

type Position = int*int
type Color = 
    | Red
    | Green
    | Blue
type Block = Position*Color
type Grid = Block seq

let generateGrid width height : Grid =
    let random = Random()
    seq {
        for x in 0..width do 
            for y in 0..height do 
                let color = match random.Next(3) with| 0 -> Red | 1 -> Green | 2 ->Blue | _ -> failwith "impossible"        
                yield ((x,y),color)
            }

let image = new Bitmap(__SOURCE_DIRECTORY__ + @"\Content\sprites.png")
let buffer = new Bitmap(600,600)
let gbuffer = Graphics.FromImage(buffer)
let renderGrid (g:Graphics, grid:Grid) =
    let size = 14
    gbuffer.Clear(Color.Black)
    for ((x,y),color) in grid do
        gbuffer.DrawImage(image,x*14,y*14,Rectangle(697, 616, size, size),GraphicsUnit.Pixel)
    g.DrawImage(buffer,0,0)

let form = new Form(Width=600,Height=600,Visible=true,TopMost=true)
let panel = new Panel(Dock=DockStyle.Fill,BackColor=Color.White) 
let graphics = panel.CreateGraphics()
form.Controls.Add(panel)     

let nothing = fun (graphics:Graphics) (state:Grid) -> state
let mutable render = nothing

let grid = generateGrid 10 10

let renderFrame g grid = 
    renderGrid (graphics, grid)
    grid


let rec test(graphics, state:Grid) = 
    async {
        let state' = render graphics state
        do! Async.Sleep(30)

        // Tail recursive call, state is stored in stack
        // How to avoid huge state in stack ?
        // What not to do: Put all state in one big struct !
        //  Will cause too much copying of data in stack between mutations
        //  If one small bit of data change -> copy everything
        // Instead Use lists (Lists are optimized for updates): one list for each aspect (like SQL Tables) and mutate the lists
        // The state is now only references to these lists
        do! test(graphics,state')
    }
// This is going to be scheduled on the same thread ! thanks to synchronisation context magic
test(graphics,grid) |> Async.Start
render <- renderFrame

