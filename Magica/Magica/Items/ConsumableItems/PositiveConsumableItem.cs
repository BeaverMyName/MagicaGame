using Magica.Objects.Units;

namespace Magica.Items.ConsumableItems
{
    /// <summary>
    /// Class that represents all the positive consumable items in the game.
    /// </summary>
    internal class PositiveConsumableItem : EffectConsumableItem<Hero>
    {
        private int hp;

        /// <summary>
        /// Initializes a new instance of the <see cref="PositiveConsumableItem"/> class.
        /// </summary>
        /// <param name="name">A name of the item.</param>
        /// <param name="effect">An effect that an item do.</param>
        /// <param name="hp">An amount of the hp that an item restore.</param>
        public PositiveConsumableItem(string name, UnitStateChanger effect, int hp)
            : base(name, effect)
        {
            this.hp = hp;
        }

        /// <summary>
        /// Gets an amount of the hp that an item restore.
        /// </summary>
        public int Hp
        {
            get
            {
                return this.hp;
            }
        }

        /// <summary>
        /// Unit takes an effects and hp that an item restore.
        /// </summary>
        /// <param name="unit">A target of the item.</param>
        public override void DoEffect(Hero unit)
        {
            base.DoEffect(unit);
            if (unit.CurrentHp + this.hp >= unit.MaxHp)
            {
                unit.CurrentHp = unit.MaxHp;
            }
            else
            {
                unit.CurrentHp += this.hp;
            }
        }
    }
}
