#r "WindowsBase"
#r "PresentationCore"
#r "PresentationFramework"
#r "System.Xaml"
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

type Position = float32*float32
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
                yield ((float32(x),float32(y)),color)
            }


type MyCanvas() =
    inherit Canvas()
    override x.OnRender ( dc:DrawingContext)  = 
      let img = new BitmapImage (new Uri (@"C:\perso\SwapIt\SwapIt.Domain.Fs\Content\sprites.png"));
      dc.DrawImage (img, new Rect (float(0), float(0), float(img.PixelWidth), float(img.PixelHeight)))

let renderGrid (canvas:Canvas, grid:Block seq) =
    let image = BitmapImage(Uri(@"C:\perso\SwapIt\SwapIt.Domain.Fs\Content\sprites.png"))
    let size = 14
    for ((x,y),color) in grid do
        let rect = 
            match color with
                | _ -> Rectangle(697, 616, size, size);
        spriteBatch.Draw(colors, new Vector2(x * 15.0f, y * 15.0f), Nullable(rect), Microsoft.Xna.Framework.Color.White);
        canvas.

let win = new Window()
let canvas = new MyCanvas()
canvas.Background <- Brushes.White
win.Content <- canvas
win.Show()        

//type Game1() as this = 
//    inherit Game()
//    do this.Content.RootDirectory <- @"Content"
//    
//    let graphics = new GraphicsDeviceManager(this)
//    let mutable spriteBatch = null
//    let mutable colors = null
//
//    member val OnDraw = (fun(sb,colors) -> ()) with get, set
//
//    override x.Initialize() =
//        base.Initialize()
//
//    override x.LoadContent() =
//        colors <- x.Content.Load<Texture2D>(@"sprites")
//        spriteBatch <- new SpriteBatch(x.GraphicsDevice)
//
//    override x.Update(gameTime) =
//        if (GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) then
//            x.Exit()
//        base.Update(gameTime)
//
//    override x.Draw(gameTime) =
//        x.GraphicsDevice.Clear(Color.Gray)
//        x.OnDraw(spriteBatch,colors)
//        base.Draw(gameTime)
//
//let grid = generateGrid 10 10
//let game = new Game1()
//game.OnDraw <- fun(sb,colors) -> renderGrid(sb,colors,grid)
//game.OnDraw <- fun(sb,colors) -> ()
//
//do game.Run()
//
//printfn "Thread is now %A" System.Threading.Thread.CurrentThread.ManagedThreadId
//let syncContext = System.Threading.SynchronizationContext.Current
//async {
//    do! Async. SwitchToContext(syncContext)
//    printfn "Thread is now %A" System.Threading.Thread.CurrentThread.ManagedThreadId
//    game.Run()
//} |> Async.Start
//
//let start() = 
//    let game = new Game1()
//    game.Run()
//let thread = Thread start
//thread.IsBackground <- true
//thread.SetApartmentState ApartmentState.STA
//thread.Start()
//
//Environment.CurrentDirectory <- __SOURCE_DIRECTORY__
//Environment.SetEnvironmentVariable("Path",
//    Environment.GetEnvironmentVariable("Path") + ";" + __SOURCE_DIRECTORY__)
//System.IO.Directory.SetCurrentDirectory(__SOURCE_DIRECTORY__)