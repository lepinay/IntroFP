//#r "System.Runtime"
#r @"C:\Program Files (x86)\MSBuild\..\MonoGame\v3.0\Assemblies\Windows\MonoGame.Framework.dll"
// http://bruinbrown.wordpress.com/2013/10/21/f-interactive-for-level-design/

open System
open System.Collections.Generic
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open Microsoft.Xna.Framework.Storage
open Microsoft.Xna.Framework.GamerServices

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

generateGrid 10 10

let renderGrid (spriteBatch:SpriteBatch, colors:Texture2D, grid:Block seq) =
    let size = 14
    spriteBatch.Begin()
    for ((x,y),color) in grid do
        let rect = 
            match color with
                | _ -> Rectangle(697, 616, size, size);
        spriteBatch.Draw(colors, new Vector2(x * 15.0f, y * 15.0f), Nullable(rect), Microsoft.Xna.Framework.Color.White);
    spriteBatch.End()
        
type Game1() as this = 
    inherit Game()
//    do this.Content.RootDirectory <- __SOURCE_DIRECTORY__ + "\\Content"
    
    let graphics = new GraphicsDeviceManager(this)
    let mutable spriteBatch = null
    let mutable colors = null

    member val OnDraw = (fun(sb,colors) -> ()) with get, set

    override x.Initialize() =
        base.Initialize()

    override x.LoadContent() =
        colors <- x.Content.Load<Texture2D>(@"..\..\..\..\..\..\perso\SwapIt\SwapIt.Domain.Fs\Content\sprites.png")
        spriteBatch <- new SpriteBatch(x.GraphicsDevice)

    override x.Update(gameTime) =
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) then
            x.Exit()
        base.Update(gameTime)

    override x.Draw(gameTime) =
        x.GraphicsDevice.Clear(Color.Black)
        x.OnDraw(spriteBatch,colors)
        base.Draw(gameTime)

let game = new Game1()
game.OnDraw <- fun(sb,colors) -> ()
do game.Run()



