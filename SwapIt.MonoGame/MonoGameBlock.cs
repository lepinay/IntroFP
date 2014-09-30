using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SwapIt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapIt.MonoGame
{
    public class MonoGameBlock : Block
    {
        private SpriteBatch sprite;
        private Texture2D colors;

        public MonoGameBlock(Position position, SpriteBatch sprite, Domain.Color color, Texture2D colors):base(position)
        {
            this.Color = color;
            this.sprite = sprite;
            this.colors = colors;
        }

        public override void Render()
        {
            Rectangle rect;
            Microsoft.Xna.Framework.Color color;
            switch (Color)
            {
                case SwapIt.Domain.Color.Red:
                    rect = new Rectangle(2, 0, 14, 14);
                    color = Microsoft.Xna.Framework.Color.Red;
                    break;
                case SwapIt.Domain.Color.Green:
                    rect = new Rectangle(2, 0, 14, 14);
                    color = Microsoft.Xna.Framework.Color.Green;
                    break;
                case SwapIt.Domain.Color.Blue:
                    rect = new Rectangle(2, 0, 14, 14);
                    color = Microsoft.Xna.Framework.Color.Blue;
                    break;
                default:
                    throw new ArgumentException("Not handled: ", Color.ToString());
            }
            sprite.Begin(SpriteSortMode.Texture,BlendState.Opaque,SamplerState.PointClamp,DepthStencilState.None,RasterizerState.CullNone);
            sprite.Draw(colors, new Vector2(Position.X * 15, Position.Y * 15), rect, color);
            sprite.End();
        }
    }
}
