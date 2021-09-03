using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Battles;

namespace Magica.Objects.Units.Skills.AttackSkills
{
    class Strike : AttackSkill
    {
        public Strike(int dmg, string[] asset, string name, int manaCost) : base(dmg, asset, name, manaCost)
        {

        }

        public override bool Action(Unit caster, Unit target)
        {
            if (base.Action(caster, target))
            {
                Battle.ChangeLog($"{caster.Name} use on {target.Name} Spell: {Name} | DMG: {caster.Dmg + Dmg}");
                return true;
            }
            return false;
        }
    }
}
