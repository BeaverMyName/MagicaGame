using System;
using Magica.Interfaces;

namespace Magica.Objects
{
    /// <summary>
    /// Class that represents all the objects on the level.
    /// </summary>
    public class GameObject : IObject
    {
        private readonly char symbol;
        private int y;
        private int x;
        private ConsoleColor color;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject"/> class.
        /// </summary>
        /// <param name="y">A vertical position on the level.</param>
        /// <param name="x">A gorizontal position on the level.</param>
        /// <param name="symbol">An appearance on the level.</param>
        /// <param name="color">A color.</param>
        public GameObject(int y, int x, char symbol, ConsoleColor color)
        {
            this.y = y;
            this.x = x;
            this.symbol = symbol;
            this.color = color;
        }

        /// <summary>
        /// Gets an appearance of the object on the level.
        /// </summary>
        public char Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// Gets or sets a vertical position on the level.
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        /// <summary>
        /// Gets or sets a gorizontal position on the level.
        /// </summary>
        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        /// <summary>
        /// Gets or sets a color.
        /// </summary>
        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }
    }
}
