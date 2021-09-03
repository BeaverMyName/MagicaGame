using Magica.Items.Weapons;
using Magica.Items.Armors;
using Magica.Items.ConsumableItems;

namespace Magica.GameAssets
{
    /// <summary>
    /// Class that contains examples of the items.
    /// </summary>
    internal static class ItemExamples
    {
        public static readonly Sword Katana = new Sword("Katana", 30, Spells.WeakStrike, Spells.Swipe);
        public static readonly Sword WoodSword = new Sword("Wood Sword", 5, Spells.WeakStrike);

        public static readonly Staff FireStaff = new Staff("Fire Staff", 20, Spells.FireBall);

        public static readonly Shield WoodShield = new Shield("Wood Shield", 5, Spells.ShieldBlock);

        public static readonly PositiveConsumableItem SmallHP = new PositiveConsumableItem("Small Heal Potion", null, 20);
        public static readonly NegativeConsumableItem Molotov = new NegativeConsumableItem("Molotov", Effects.OnFire, 0);
    }
}
