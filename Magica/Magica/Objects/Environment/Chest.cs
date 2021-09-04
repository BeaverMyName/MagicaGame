using System;
using Magica.Objects.Units;
using Magica.Interfaces;

namespace Magica.Objects.Environment
{
    /// <summary>
    /// Class that represents all the chests in the game.
    /// </summary>
    internal class Chest : GameObject, IOpenable
    {
        private IItem[] items;

        /// <summary>
        /// Initializes a new instance of the <see cref="Chest"/> class.
        /// </summary>
        /// <param name="y">A vertical position of the chest.</param>
        /// <param name="x">A gorizontal position of the chest.</param>
        /// <param name="items">An array that contains all the items in the chest.</param>
        /// <param name="color">A color of the chest.</param>
        public Chest(int y, int x, ConsoleColor color, params IItem[] items)
            : base(y, x, '\u00A4', color)
        {
            this.items = items;
        }

        /// <summary>
        /// Takes items from the chest to the hero inventory.
        /// </summary>
        /// <param name="hero">Current hero.</param>
        public void TakesItems(Hero hero)
        {
            hero.Inventory.ChangeInventory(true, this.items);
            this.items = new IItem[0];
            this.Color = ConsoleColor.Gray;
        }

        /// <summary>
        /// Opens the chest.
        /// </summary>
        public void Open()
        {
            this.Color = ConsoleColor.Green;
        }
    }
}
