using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Objects.Units;
using Magica.Interfaces;

namespace Magica.Objects.Environment
{
    /// <summary>
    /// Class that represents all chests in the game.
    /// </summary>
    class Chest : GameObject
    {
        private IItem[] items;

        public Chest(int y, int x, params IItem[] items) : base (y, x, '\u00A4', ConsoleColor.Green) 
        {
            this.items = items;
        }

        /// <summary>
        /// Open the chest and add all items to the hero inventory.
        /// </summary>
        /// <param name="hero">Current hero</param>
        public void Open(Hero hero)
        {
            hero.Inventory.ChangeInventory(true, items);
            items = new IItem[0];
            Color = ConsoleColor.Gray;
        }
    }
}
