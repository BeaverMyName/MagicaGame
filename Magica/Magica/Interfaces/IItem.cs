using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Interfaces
{
    /// <summary>
    /// All items in the game must implement the interface IItem.
    /// </summary>
    interface IItem
    {
        public string Name { get; set; }
    }
}
