using System;

namespace Magica.Objects.Environment
{
    /// <summary>
    /// Class that represents all the floors in the game.
    /// </summary>
    internal class Floor : GameObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Floor"/> class.
        /// </summary>
        /// <param name="y">A vertical position of the floor.</param>
        /// <param name="x">A gorizontal position of the floor.</param>
        public Floor(int y, int x)
            : base(y, x, '.', ConsoleColor.White)
        {
        }
    }
}
