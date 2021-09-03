using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Objects.Units.Skills.AttackSkills;
using Magica.Objects.Units.Skills.DefenceSkills;

namespace Magica.GameAssets
{
    /// <summary>
    /// Class that contains examples of the spells.
    /// </summary>
    static class Spells
    {
        public static FireSkill fireBall = new FireSkill(20, Assets.Staff, "Fire Ball", 40);
        public static Strike weakStrike = new Strike(0, Assets.Sword, "W. Strike", 0);
        public static PiercingStrike swipe = new PiercingStrike(10, Assets.Sword, "Swipe", 15);

        public static Block shieldBlock = new Block(Assets.Shield, "Block", 0);
    }
}
