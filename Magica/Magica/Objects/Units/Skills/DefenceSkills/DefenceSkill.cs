using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magica.Objects.Units.Skills.DefenceSkills
{
    /// <summary>
    /// Class that represents all the defence skills in the game.
    /// </summary>
    internal abstract class DefenceSkill : Skill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefenceSkill"/> class.
        /// </summary>
        /// <param name="asset">An array that contains the appearance of the skill.</param>
        /// <param name="name">A name of the skill.</param>
        /// <param name="manaCost">An amount of the manacost of the skill.</param>
        public DefenceSkill(string[] asset, string name, int manaCost)
            : base(asset, name, manaCost)
        {
        }

        /// <summary>
        /// Does an action of the skill.
        /// </summary>
        /// <param name="caster">Unit that casts the skill.</param>
        /// <param name="target">Unit that takes the effect of the skill.</param>
        /// <returns>Whether caster has enough mana to cast the skill.</returns>
        public override bool DoAction(Unit caster, Unit target)
        {
            if (base.DoAction(caster, target))
            {
                return true;
            }

            return false;
        }
    }
}
