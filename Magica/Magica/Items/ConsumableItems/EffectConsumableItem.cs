using Magica.Objects.Units;

namespace Magica.Items.ConsumableItems
{
    /// <summary>
    /// Class that represents all consumable items in the game.
    /// </summary>
    /// <typeparam name="T">Hero if item is positive and Monser if - negative.</typeparam>
    internal class EffectConsumableItem<T> : Item
        where T : Unit
    {
        private UnitStateChanger itemEffect;

        /// <summary>
        /// Initializes a new instance of the <see cref="EffectConsumableItem{T}"/> class.
        /// </summary>
        /// <param name="name">A name of the item.</param>
        /// <param name="effect">Effects that an item do.</param>
        public EffectConsumableItem(string name, UnitStateChanger effect)
            : base(name)
        {
            this.itemEffect = effect;
        }

        /// <summary>
        /// Gets the effects that an item do.
        /// </summary>
        public UnitStateChanger ItemEffect
        {
            get
            {
                return this.itemEffect;
            }
        }

        /// <summary>
        /// Unit takes the effects that an item do.
        /// </summary>
        /// <param name="unit">A unit that takes the effects.</param>
        public virtual void DoEffect(T unit)
        {
            unit.UnitState += this.itemEffect;
        }
    }
}
