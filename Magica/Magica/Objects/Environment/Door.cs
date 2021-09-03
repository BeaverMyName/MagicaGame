using System;

namespace Magica.Objects.Environment
{
    /// <summary>
    /// Class that represents all the doors in the game.
    /// </summary>
    internal class Door : GameObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Door"/> class.
        /// </summary>
        /// <param name="y">A vertical position of the door.</param>
        /// <param name="x">A gorizontal position of the door.</param>
        public Door(int y, int x)
            : base(y, x, 'H', ConsoleColor.Green)
        {
        }
    }
}
