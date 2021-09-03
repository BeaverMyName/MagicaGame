using Magica.GameAssets;
using Magica.Battles;

namespace Magica.Objects.Units.Skills.AttackSkills
{
    /// <summary>
    /// Class that represents all the fire skills in the game.
    /// </summary>
    internal class FireSkill : AttackSkill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FireSkill"/> class.
        /// </summary>
        /// <param name="dmg">An amount of the damage that the fire skill does.</param>
        /// <param name="asset">An array that contains the appearance of the fire skill.</param>
        /// <param name="name">A name of the fire skill.</param>
        /// <param name="manaCost">An amount of the manacost of the fire skill.</param>
        public FireSkill(int dmg, string[] asset, string name, int manaCost)
            : base(dmg, asset, name, manaCost)
        {
        }

        /// <summary>
        /// Does an action of the fire skill.
        /// </summary>
        /// <param name="caster">Unit that casts the fire skill.</param>
        /// <param name="target">Unit that takes the effect of the fire skill.</param>
        /// <returns>Whether caster has enough mana to cast the fire skill.</returns>
        public override bool DoAction(Unit caster, Unit target)
        {
            if (base.DoAction(caster, target))
            {
                target.UnitState -= Effects.OnFire;
                target.UnitState += Effects.OnFire;
                Battle.ChangeLog($"{caster.Name} use on {target.Name} Spell: {this.Name} | DMG: {caster.Dmg + this.Dmg} | Effects: Fire");
                return true;
            }

            return false;
        }
    }
}
