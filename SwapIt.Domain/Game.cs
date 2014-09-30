using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwapIt.Domain
{
    public class Game
    {
        private int width;
        private int height;
        public IList<Block> Grid { get; private set; }
        public Selector Selector { get; set; }

        public Game(IBlockFactory factory, int width, int height)
        {
            this.width = width;
            this.height = height;


            Grid = new List<Block>();
            var rand = new Random();
            for (var x = 0; x < height; x++)
                for (var y = 0; y < height; y++)
                {
                    var color = (Color)rand.Next(1+(int)Color.Blue);
                    Grid.Add(factory.Make(new Position { X = x, Y = y }, color));
                }

        }

        public void Render()
        {
            for (var i = 0; i < width * height; i++)
            {
                var block = Grid[i];
                block.Render();
            }
        }
    }
}
