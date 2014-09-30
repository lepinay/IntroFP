using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwapIt.Domain
{
    public abstract class Block
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public abstract void Render();

        public Block(Position position)
        {
            this.Position = position;
        }
    }
}
