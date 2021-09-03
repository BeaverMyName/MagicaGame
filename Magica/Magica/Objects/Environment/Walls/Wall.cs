using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Objects.Environment.Walls
{
    class Wall : GameObject
    {
        public Wall(int y, int x, char symbol) : base(y, x, symbol, ConsoleColor.White) { }
    }
}
