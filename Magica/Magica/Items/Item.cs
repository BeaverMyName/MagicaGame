using Magica.Interfaces;

namespace Magica.Items
{
    /// <summary>
    /// Abstract class that represents all the items in the game.
    /// </summary>
    internal abstract class Item : IItem
    {
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="name">A name of the item.</param>
        public Item(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Gets a name of the item.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Returns a string with all characteristics of the item.
        /// </summary>
        /// <returns>A string with all characteristics of the item.</returns>
        public override string ToString()
        {
            return $"{this.name}";
        }
    }
}
