using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwapIt.Domain
{
    public abstract class Selector
    {
        public Position Position { get; set; }
        public abstract void Render();
    }
}
