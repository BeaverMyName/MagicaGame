namespace Magica.Objects.Environment.Walls
{
    /// <summary>
    /// Class that represents all the vertical walls in the game.
    /// </summary>
    internal class VerticalWall : Wall
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VerticalWall"/> class.
        /// </summary>
        /// <param name="y">A vertical position of the wall.</param>
        /// <param name="x">A gorizontal position of the wall.</param>
        public VerticalWall(int y, int x)
            : base(y, x, '|')
        {
        }
    }
}
