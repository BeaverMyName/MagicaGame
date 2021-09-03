using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Objects.Units.Skills.DefenceSkills
{
    /*
     * Class that represents defence skills in the game. Skill should inherit from the DefenceSkill class if it doesn't damage.
     */
    class DefenceSkill : Skill
    {
        public DefenceSkill(string[] asset, string name, int manaCost) : base(asset, name, manaCost) { }

        public override bool Action(Unit caster, Unit target)
        {
            if (base.Action(caster, target))
            {
                return true;
            }
            return false;
        }
    }
}
