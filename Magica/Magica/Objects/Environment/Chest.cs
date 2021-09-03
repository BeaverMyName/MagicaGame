using System;
using Magica.Objects.Units;
using Magica.Interfaces;

namespace Magica.Objects.Environment
{
    /// <summary>
    /// Class that represents all the chests in the game.
    /// </summary>
    internal class Chest : GameObject
    {
        private IItem[] items;

        /// <summary>
        /// Initializes a new instance of the <see cref="Chest"/> class.
        /// </summary>
        /// <param name="y">A vertical position of the chest.</param>
        /// <param name="x">A gorizontal position of the chest.</param>
        /// <param name="items">An array that contains all the items in the chest.</param>
        public Chest(int y, int x, params IItem[] items)
            : base(y, x, '\u00A4', ConsoleColor.Green)
        {
            this.items = items;
        }

        /// <summary>
        /// Opens the chest and adds all items to the hero's inventory.
        /// </summary>
        /// <param name="hero">Current hero.</param>
        public void Open(Hero hero)
        {
            hero.Inventory.ChangeInventory(true, this.items);
            this.items = new IItem[0];
            this.Color = ConsoleColor.Gray;
        }
    }
}
