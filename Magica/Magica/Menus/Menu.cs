using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Menus
{
    /// <summary>
    /// Class that represents all menus in the game.
    /// </summary>
    class Menu
    {
        public string[] Items { get; set; }

        public Menu(string[] items)
        {
            Items = items;
        }

        /// <summary>
        /// Display the current menu
        /// </summary>
        /// <param name="pointer"></param>
        public void DisplayMenu(int pointer)
        {
            for(int i = 0; i < Items.Length; i++)
            {
                if (i == pointer)
                    Console.Write("-> ");
                Console.WriteLine(Items[i]);
            }
        }
    }
}
