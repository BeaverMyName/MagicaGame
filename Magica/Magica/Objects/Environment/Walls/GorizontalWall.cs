namespace Magica.Objects.Environment.Walls
{
    /// <summary>
    /// Class that represents all the gorizontal walls in the game.
    /// </summary>
    internal class GorizontalWall : Wall
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GorizontalWall"/> class.
        /// </summary>
        /// <param name="y">A vertical position of the wall.</param>
        /// <param name="x">A gorizontal position of the wall.</param>
        public GorizontalWall(int y, int x)
            : base(y, x, '\u0016')
        {
        }
    }
}
