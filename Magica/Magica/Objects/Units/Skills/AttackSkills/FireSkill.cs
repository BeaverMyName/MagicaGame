using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.GameAssets;
using Magica.Battles;

namespace Magica.Objects.Units.Skills.AttackSkills
{
    class FireSkill : AttackSkill
    {
        public FireSkill(int dmg, string[] asset, string name, int manaCost) : base (dmg, asset, name, manaCost) 
        {

        }

        public override bool Action(Unit caster, Unit target)
        {
            if (base.Action(caster, target))
            {
                target.UnitState -= Effects.OnFire;
                target.UnitState += Effects.OnFire;
                Battle.ChangeLog($"{caster.Name} use on {target.Name} Spell: {Name} | DMG: {caster.Dmg + Dmg} | Effects: Fire");
                return true;
            }
            return false;
        }
    }
}
