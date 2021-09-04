using Magica.Objects.Units;

namespace Magica.Items.ConsumableItems
{
    /// <summary>
    /// Abstract class that represents all the consumable items in the game.
    /// </summary>
    /// <typeparam name="T">Hero if item is positive and Monser if - negative.</typeparam>
    internal abstract class ConsumableItem<T> : Item
        where T : Unit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableItem{T}"/> class.
        /// </summary>
        /// <param name="name">A name.</param>
        public ConsumableItem(string name)
            : base(name)
        {
        }
    }
}
