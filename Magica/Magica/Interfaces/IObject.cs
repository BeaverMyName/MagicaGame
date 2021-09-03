using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Interfaces
{
    /// <summary>
    /// All game objects that placed on the level must implement the IObject interface.
    /// </summary>
    interface IObject
    {
        public int Y { get; set; }
        public int X { get; set; }
        public char Symbol { get; }
        public ConsoleColor Color { get; }
    }
}
