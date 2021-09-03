using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Interfaces;

namespace Magica.Items
{
    /// <summary>
    /// Class that represents all items in the game.
    /// </summary>
    abstract class Item : IItem
    {
        private string name;
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Item(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $"{name}";
        }
    }
}
