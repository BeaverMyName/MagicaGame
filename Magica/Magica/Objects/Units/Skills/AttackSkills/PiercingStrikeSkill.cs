using Magica.GameAssets;
using Magica.Battles;

namespace Magica.Objects.Units.Skills.AttackSkills
{
    /// <summary>
    /// Class that represents all the piercing strike skills in the game.
    /// </summary>
    internal class PiercingStrikeSkill : AttackSkill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PiercingStrikeSkill"/> class.
        /// </summary>
        /// <param name="dmg">An amount of the damage that the piercing strike skill does.</param>
        /// <param name="asset">An array that contains the appearance of the piercing strike skill.</param>
        /// <param name="name">A name of the piercing strike skill.</param>
        /// <param name="manaCost">An amount of the manacost of the piercing strike skill.</param>
        public PiercingStrikeSkill(int dmg, string[] asset, string name, int manaCost)
            : base(dmg, asset, name, manaCost)
        {
        }

        /// <summary>
        /// Does an action of the piercing strike skill.
        /// </summary>
        /// <param name="caster">Unit that casts the piercing strike skill.</param>
        /// <param name="target">Unit that takes the effect of the piercing strike skill.</param>
        /// <returns>Whether caster has enough mana to cast the piercing strike skill.</returns>
        public override bool DoAction(Unit caster, Unit target)
        {
            if (base.DoAction(caster, target))
            {
                target.UnitState -= Effects.Bleeding;
                target.UnitState += Effects.Bleeding;
                Battle.ChangeLog($"{caster.Name} use on {target.Name} Spell: {this.Name} | DMG: {caster.Dmg + this.Dmg} | Effects: Bleeding");
                return true;
            }

            return false;
        }
    }
}
