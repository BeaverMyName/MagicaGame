using Magica.Objects.Units.Skills.AttackSkills;
using Magica.Objects.Units.Skills.DefenceSkills;

namespace Magica.GameAssets
{
    /// <summary>
    /// Class that contains examples of the spells.
    /// </summary>
    internal static class Spells
    {
        public static readonly FireSkill FireBall = new FireSkill(20, Assets.Staff, "Fire Ball", 40);
        public static readonly StrikeSkill WeakStrike = new StrikeSkill(0, Assets.Sword, "W. Strike", 0);
        public static readonly PiercingStrikeSkill Swipe = new PiercingStrikeSkill(10, Assets.Sword, "Swipe", 15);

        public static readonly Block ShieldBlock = new Block(Assets.Shield, "Block", 0);
    }
}
