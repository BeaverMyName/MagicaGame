using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.GameAssets;
using Magica.Battles;

namespace Magica.Objects.Units.Skills.AttackSkills
{
    class PiercingStrike : AttackSkill
    {
        public PiercingStrike(int dmg, string[] asset, string name, int manaCost) : base(dmg, asset, name, manaCost) { }

        public override bool Action(Unit caster, Unit target)
        {
            if (base.Action(caster, target))
            {
                target.UnitState -= Effects.Bleeding;
                target.UnitState += Effects.Bleeding;
                Battle.ChangeLog($"{caster.Name} use on {target.Name} Spell: {Name} | DMG: {caster.Dmg + Dmg} | Effects: Bleeding");
                return true;
            }
            return false;
        }
    }
}
