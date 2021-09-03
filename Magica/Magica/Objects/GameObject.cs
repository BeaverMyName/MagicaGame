using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Interfaces;

namespace Magica.Objects
{
    /// <summary>
    /// Class that represents all objects on the level.
    /// </summary>
    public class GameObject : IObject
    {
        private int y;
        private int x;
        private char symbol;
        private ConsoleColor color;

        /// <summary>
        /// y position on the level.
        /// </summary>
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// x position on the level.
        /// </summary>
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// Visual appearance of object on the level.
        /// </summary>
        public char Symbol
        {
            get
            {
                return symbol;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public GameObject(int y, int x, char symbol, ConsoleColor color)
        {
            this.y = y;
            this.x = x;
            this.symbol = symbol;
            this.color = color;
        }
    }
}
