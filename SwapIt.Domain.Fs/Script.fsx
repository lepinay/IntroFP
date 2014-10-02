#r "WindowsBase"
#r "PresentationCore"
#r "PresentationFramework"
#r "System.Xaml"
#r "UiAutomationTypes"
open System
open System.Windows
open System.Windows.Media
open System.Windows.Shapes
open System.Windows.Controls

open System
open System.Collections.Generic
open System.Threading.Tasks
open System.Threading
open System.Windows.Media.Imaging
open System.Globalization

open System.Windows.Forms 
open System.Drawing

type Position = int*int
type Color = 
    | Red
    | Green
    | Blue
type Block = Position*Color
type Grid = Block list

let generateGrid width height : Block seq =
    let random = Random()
    seq {
        for x in 0..width do 
            for y in 0..height do 
                let color = match random.Next(3) with| 0 -> Red | 1 -> Green | 2 ->Blue | _ -> failwith "impossible"        
                yield ((x,y),color)
            }


//type MyCanvas() =
//    inherit Canvas()
//    let mutable renderer = (fun dc -> ())
//
//    member x.SetRenderer f = 
//        renderer <- f
//    
//    member val render:DrawingContext -> unit = 
//        (fun dc -> ()) with get, set
//
//    override x.OnRender ( dc:DrawingContext)  = 
//        base.OnRender(dc)
//        renderer dc

let renderGrid (g:Graphics, grid:Block seq) =
    let image = new Bitmap(__SOURCE_DIRECTORY__ + @"\Content\sprites.png")
    let size = 14
    g.Clear(Color.Black)
    for ((x,y),color) in grid do
        g.DrawImage(image,x*14,y*14,Rectangle(697, 616, size, size),GraphicsUnit.Pixel)

//let win = new Window()
//let canvas = new MyCanvas()
//let img = new BitmapImage (new Uri (@"D:\code\swapit\SwapIt.Domain.Fs\Content\sprites.png"));
//let img2 = new Image()
//img2.Source <- img
//canvas.Children.Add(img2)
//canvas.SetRenderer ( fun (dc:DrawingContext) ->
//        let img = new BitmapImage (new Uri (@"D:\code\swapit\SwapIt.Domain.Fs\Content\sprites.png"));
//        dc.DrawImage (img, new Rect (float(0), float(0), float(img.PixelWidth), float(img.PixelHeight)))
//    )
//
//canvas.Background <- Brushes.Red
//win.Content <- canvas
//win.Show()        

let form = new Form() 
form.Width  <- 600 
form.Height <- 600 
form.Visible <- true  
let panel = new Panel() 
panel.Dock <- DockStyle.Fill
panel.BackColor <- Color.White
form.Controls.Add(panel)     
let graphics = panel.CreateGraphics()
let grid = generateGrid 10 10
renderGrid (graphics, grid)
let image = new Bitmap(__SOURCE_DIRECTORY__ + @"\Content\sprites.png")
graphics.Clear(Color.Black)
graphics.DrawImage(image, 0,0)
