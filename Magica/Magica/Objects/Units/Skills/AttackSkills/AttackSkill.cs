using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Objects.Units.Skills;

namespace Magica.Objects.Units.Skills.AttackSkills
{
    /*
     * Class that represents attack skills in the game. Skill should inherit from the AtackSkill class if it does damage.
     */
    class AttackSkill : Skill
    {
        private int dmg;

        public int Dmg
        {
            get
            {
                return dmg;
            }
        }

        public AttackSkill(int dmg, string[] asset, string name, int manaCost) : base(asset, name, manaCost)
        {
            this.dmg = dmg;
        }

        public override bool Action(Unit caster, Unit target)
        {
            if (base.Action(caster, target))
            {
                target.CurrentHp -= (caster.Dmg + dmg);
                return true;
            }
            return false;
        }
    }
}
