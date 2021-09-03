using System;

namespace Magica.Objects.Environment.Walls
{
    /// <summary>
    /// Abstract class that represents all the walls in the game.
    /// </summary>
    internal abstract class Wall : GameObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Wall"/> class.
        /// </summary>
        /// <param name="y">A vertical position of the wall.</param>
        /// <param name="x">A gorizontal position of the wall.</param>
        /// <param name="symbol">An appearance of the wall.</param>
        public Wall(int y, int x, char symbol)
            : base(y, x, symbol, ConsoleColor.White)
        {
        }
    }
}
