using System;

namespace Magica.Interfaces
{
    /// <summary>
    /// All movable objects in the game must implement the interface IMovable.
    /// </summary>
    internal interface IMovable
    {
        /// <summary>
        /// Gets or sets a value indicating whether unit have moved.
        /// </summary>
        public bool HaveMoved { get; set; }

        /// <summary>
        /// Moves the unit.
        /// </summary>
        /// <param name="field">A current level.</param>
        public void Move(IField field);

        /// <summary>
        /// Checks whether the collision object is a specific type.
        /// </summary>
        /// <param name="obj">Checkable object.</param>
        /// <param name="type">Specific type.</param>
        /// <returns>Whether the collision object is a specific type.</returns>
        public bool CheckCollision(IObject obj, Type type);

        /// <summary>
        /// Finds an object around the unit.
        /// </summary>
        /// <param name="field">Current level.</param>
        /// <param name="type">Specific type.</param>
        /// <param name="color">Color of the object.</param>
        /// <returns>An object with the specific type or null.</returns>
        public IObject CheckCollisionAround(IField field, Type type, ConsoleColor color);
    }
}
