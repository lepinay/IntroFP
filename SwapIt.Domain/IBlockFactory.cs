using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwapIt.Domain
{
    public interface IBlockFactory
    {
        Block Make(Position position, Color color);
    }
}
