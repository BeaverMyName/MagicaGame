using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Objects.Environment.Walls
{
    class VerticalWall : Wall
    {
        public VerticalWall(int y, int x) : base(y, x, '|') { }
    }
}
