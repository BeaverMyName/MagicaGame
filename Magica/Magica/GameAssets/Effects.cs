using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Objects.Units;
using Magica.Battles;

namespace Magica.GameAssets
{
    /// <summary>
    /// Class that contains examples of the effects.
    /// </summary>
    static class Effects
    {
        public static void OnFire(Unit target)
        {
            target.CurrentHp -= 10;
            Battle.ChangeLog($"{target.Name} take 10 dmg from Fire");
        }

        public static void Bleeding(Unit target)
        {
            target.CurrentHp -= 5;
            Battle.ChangeLog($"{target.Name} take 5 dmg from Bleeding");
        }
    }
}
