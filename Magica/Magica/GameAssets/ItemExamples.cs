using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Items.Weapons;
using Magica.Items.Armors;
using Magica.Objects.Units.Skills.AttackSkills;
using Magica.Objects.Units.Skills.DefenceSkills;
using Magica.GameAssets;
using Magica.Items.ConsumableItems;

namespace Magica.GameAssets
{
    /// <summary>
    /// Class that contains examples of the items.
    /// </summary>
    static class ItemExamples
    {
        public static Sword katana = new Sword("Katana", 30, Spells.weakStrike, Spells.swipe);
        public static Sword woodSword = new Sword("Wood Sword", 5, Spells.weakStrike);

        public static Staff fireStaff = new Staff("Fire Staff", 20, Spells.fireBall);

        public static Shield woodShield = new Shield("Wood Shield", 5, Spells.shieldBlock);

        public static PositiveConsumableItem smallHP = new PositiveConsumableItem("Small Heal Potion", null, 20);
        public static NegativeConsumableItem molotov = new NegativeConsumableItem("Molotov", Effects.OnFire, 0);
    }
}
