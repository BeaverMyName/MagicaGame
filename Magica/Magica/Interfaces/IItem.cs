namespace Magica.Interfaces
{
    /// <summary>
    /// All items in the game must implement the interface IItem.
    /// </summary>
    internal interface IItem
    {
        /// <summary>
        /// Gets or sets a name of the item.
        /// </summary>
        public string Name { get; }
    }
}
