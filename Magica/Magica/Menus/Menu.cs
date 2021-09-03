using System;

namespace Magica.Menus
{
    /// <summary>
    /// Class that represents all menus in the game.
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        /// <param name="items">An array of the items of the menu.</param>
        public Menu(string[] items)
        {
            this.Items = items;
        }

        /// <summary>
        /// Gets or sets an array of the items of the menu.
        /// </summary>
        public string[] Items { get; set; }

        /// <summary>
        /// Displays the current menu.
        /// </summary>
        /// <param name="pointer">A pointer of the current menu item.</param>
        public void DisplayMenu(int pointer)
        {
            for (int i = 0; i < this.Items.Length; i++)
            {
                if (i == pointer)
                {
                    Console.Write("-> ");
                }

                Console.WriteLine(this.Items[i]);
            }
        }
    }
}
