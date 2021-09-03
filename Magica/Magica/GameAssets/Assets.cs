using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.GameAssets
{
    /// <summary>
    /// Class that contains visual assets of the objects and the skills;
    /// </summary>
    static class Assets
    {
        public static string[] Inventory
        {
            get
            {
                return new string[]
                {
                    "  ______  ",
                    "  \\    /  ",
                    "   ----   ",
                    "  /    \\  ",
                    " /      \\ ",
                    "/        \\",
                    "|        |",
                    "\\        /",
                    " \\______/ ",
                    "          "
                };
            }
        }

        public static string[] Sword
        {
            get
            {
                return new string[]
                {
                    "       -  ",
                    "      /  \\",
                    "     /   /",
                    "    /   / ",
                    "   /   /  ",
                    "  /   /   ",
                    "-------   ",
                    " / /      ",
                    "/ /       ",
                    "-         "
                };
            }
        }

        public static string[] Staff
        {
            get
            {
                return new string[]
                {
                    "      ___ ",
                    "     /   \\",
                    "     \\  _/",
                    "     / /  ",
                    "    / /   ",
                    "   / /    ",
                    "  / /     ",
                    " / /      ",
                    "/ /       ",
                    "-         "
                };
            }
        }

        public static string[] Shield
        {
            get
            {
                return new string[]
                {
                   "          ",
                   "----------",
                   "|        |",
                   "|  ____  |",
                   "|  \\  /  |",
                   "|   \\/   |",
                   "|        |",
                   "|        |",
                   "\\________/",
                   "          "
                };
            }
        }

        public static string[] Vampire
        {
            get
            {
                return new string[]
                {
                    "  |\\/-----\\/|  ",
                    " /\\|___\\/-\\ /\\ ",
                    " |.|\\O/|\\O/|.| ",
                    " \\_|--/_\\--|_/ ",
                    "   |  ___  |   ",
                    "/--| |___| |--\\",
                    "-\\ \\ |/-\\| / /-",
                    "  | \\_____/ |  "
                };
            }
        }
    }
}
