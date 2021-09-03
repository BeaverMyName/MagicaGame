using Magica.Battles;

namespace Magica.Objects.Units.Skills.AttackSkills
{
    /// <summary>
    /// Class that represents all the strike skills in the game.
    /// </summary>
    internal class StrikeSkill : AttackSkill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StrikeSkill"/> class.
        /// </summary>
        /// <param name="dmg">An amount of the damage that the strike skill does.</param>
        /// <param name="asset">An array that contains the appearance of the strike skill.</param>
        /// <param name="name">A name of the strike skill.</param>
        /// <param name="manaCost">An amount of the manacost of the strike skill.</param>
        public StrikeSkill(int dmg, string[] asset, string name, int manaCost)
            : base(dmg, asset, name, manaCost)
        {
        }

        /// <summary>
        /// Does an action of the strike skill.
        /// </summary>
        /// <param name="caster">Unit that casts the strike skill.</param>
        /// <param name="target">Unit that takes the effect of the strike skill.</param>
        /// <returns>Whether caster has enough mana to cast the strike skill.</returns>
        public override bool DoAction(Unit caster, Unit target)
        {
            if (base.DoAction(caster, target))
            {
                Battle.ChangeLog($"{caster.Name} use on {target.Name} Spell: {this.Name} | DMG: {caster.Dmg + this.Dmg}");
                return true;
            }

            return false;
        }
    }
}
