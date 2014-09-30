using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SwapIt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapIt.MonoGame
{
    public class MonoGameBlockFactory:IBlockFactory
    {
        private SpriteBatch spriteBatch;
        private Texture2D colors;
        public MonoGameBlockFactory(GraphicsDevice GraphicsDevice, ContentManager content)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //http://opengameart.org/content/puzzle-game-art
            colors = content.Load<Texture2D>("sprites");
        }
        public Block Make(Position position, Color color)
        {
            return new MonoGameBlock(position, spriteBatch, color, colors );
        }
    }
}
