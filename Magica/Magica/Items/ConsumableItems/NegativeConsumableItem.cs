using Magica.Objects.Units;

namespace Magica.Items.ConsumableItems
{
    /// <summary>
    /// Class that represents all negative consumable items in the game.
    /// </summary>
    internal class NegativeConsumableItem : EffectConsumableItem<Monster>
    {
        private int dmg;

        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeConsumableItem"/> class.
        /// </summary>
        /// <param name="name">A name of the item.</param>
        /// <param name="effect">An effect that an item do.</param>
        /// <param name="dmg">An amount of the damage that an item do.</param>
        public NegativeConsumableItem(string name, UnitStateChanger effect, int dmg)
            : base(name, effect)
        {
            this.dmg = dmg;
        }

        /// <summary>
        /// Gets an amount of the damage that an item do.
        /// </summary>
        public int Dmg
        {
            get
            {
                return this.dmg;
            }
        }

        /// <summary>
        /// Unit takes an effects and damage that an item do.
        /// </summary>
        /// <param name="unit">A target of the item.</param>
        public override void DoEffect(Monster unit)
        {
            base.DoEffect(unit);
            unit.CurrentHp -= this.dmg;
        }
    }
}
