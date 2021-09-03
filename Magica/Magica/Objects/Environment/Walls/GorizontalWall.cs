using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Objects.Environment.Walls
{
    class GorizontalWall : Wall
    {
        public GorizontalWall(int y, int x) : base(y, x, '=') { }
    }
}
