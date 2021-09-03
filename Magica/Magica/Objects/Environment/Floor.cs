using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Objects.Environment
{
    class Floor : GameObject
    {
        public Floor(int y, int x) : base (y, x, '.', ConsoleColor.White) { }
    }
}
