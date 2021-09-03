using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Interfaces
{
    /// <summary>
    /// All movable objects in the game must implement the interface IMovable.
    /// </summary>
    interface IMovable
    {
        public bool HaveMoved { get; set; }
        public void Move(IField field);
        public bool CheckCollizion(IObject obj, Type type);
        public IObject CheckCollizionAround(IField field, Type type, ConsoleColor color);
    }
}
