namespace Magica.Interfaces
{
    /// <summary>
    /// All levels in the game must implement the interface IField.
    /// </summary>
    internal interface IField
    {
        /// <summary>
        /// Gets or sets an array that contains all the objects in the game.
        /// </summary>
        public IObject[,] Field { get; set; }

        /// <summary>
        /// Initializes a level with the objects.
        /// </summary>
        /// <param name="objects">Objects of the level.</param>
        public void FieldInitialization(IObject[] objects);

        /// <summary>
        /// Display the current level.
        /// </summary>
        public void DisplayField();
    }
}
