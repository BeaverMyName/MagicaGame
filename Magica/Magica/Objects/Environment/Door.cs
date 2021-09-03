using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Objects.Environment
{
    class Door : GameObject
    {
        public Door(int y, int x) : base(y, x, 'H', ConsoleColor.Green) { }
    }
}
