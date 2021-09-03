using System;

namespace Magica.Interfaces
{
    /// <summary>
    /// All game objects that placed on the level must implement the IObject interface.
    /// </summary>
    internal interface IObject
    {
        /// <summary>
        /// Gets or sets a vertical position of the object on the level.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets a gorizontal position of the object on the level.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets an appearance of the object on the level.
        /// </summary>
        public char Symbol { get; }

        /// <summary>
        /// Gets a color of the object on the level.
        /// </summary>
        public ConsoleColor Color { get; }
    }
}
