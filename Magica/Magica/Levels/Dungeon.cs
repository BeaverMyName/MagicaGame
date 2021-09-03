using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Interfaces;

namespace Magica.Levels
{
    class Dungeon : Level
    {
        public Dungeon(int y, int x, IObject[] objects) : base (y, x, objects) { }

        public override void FieldInitialization(IObject[] objects)
        {
            base.FieldInitialization(objects);
        }
    }
}
