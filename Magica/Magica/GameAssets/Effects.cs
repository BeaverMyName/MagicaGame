using Magica.Objects.Units;
using Magica.Battles;

namespace Magica.GameAssets
{
    /// <summary>
    /// Class that contains examples of the effects.
    /// </summary>
    internal static class Effects
    {
        /// <summary>
        /// Unit takes damage from the fire.
        /// </summary>
        /// <param name="target">Unit that takes the effect.</param>
        public static void OnFire(Unit target)
        {
            target.CurrentHp -= 10;
            Battle.ChangeLog($"{target.Name} take 10 dmg from Fire");
        }

        /// <summary>
        /// Unit takes damage from the bleeding.
        /// </summary>
        /// <param name="target">Unit that takes the effect.</param>
        public static void Bleeding(Unit target)
        {
            target.CurrentHp -= 5;
            Battle.ChangeLog($"{target.Name} take 5 dmg from Bleeding");
        }
    }
}
