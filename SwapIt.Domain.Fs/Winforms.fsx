open System 
open System.Windows.Forms 
open System.Drawing
 
let form = new Form() 
form.Width  <- 600 
form.Height <- 600 
form.Visible <- true  
form.Text <- "Hello World Form" 
 
// Menu bar, menus  
let mMain = form.Menu <- new MainMenu() 
let mFile = form.Menu.MenuItems.Add("&File") 
let miQuit  = new MenuItem("&Quit") 
mFile.MenuItems.Add(miQuit) 
 
// RichTextView  
let panel = new Panel() 
panel.Dock <- DockStyle.Fill
panel.BackColor <- Color.White
panel.MouseClick.Add(fun e -> printfn "%A %A" e.X e.Y)

form.Controls.Add(panel)     
let graphics = panel.CreateGraphics()
let image = new Bitmap(__SOURCE_DIRECTORY__ + @"\Content\sprites.png")
graphics.Clear(Color.Black)
graphics.DrawImage(image, 10,0)
 
// callbacks  
miQuit.Click.Add(fun _ -> form.Close()) 