using Magica.Interfaces;

namespace Magica.Levels
{
    /// <summary>
    /// Class that represents all the dungeons in the game.
    /// </summary>
    internal class Dungeon : Level
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dungeon"/> class.
        /// </summary>
        /// <param name="y">A vertical size of the dungeon.</param>
        /// <param name="x">A gorizontal size of the dungeon.</param>
        /// <param name="objects">All objects on the dungeon.</param>
        public Dungeon(int y, int x, IObject[] objects)
            : base(y, x, objects)
        {
        }

        /// <summary>
        /// Initializes a dungeon with the objects.
        /// </summary>
        /// <param name="objects">Objects of the dungeon.</param>
        public override void FieldInitialization(IObject[] objects)
        {
            base.FieldInitialization(objects);
        }
    }
}
