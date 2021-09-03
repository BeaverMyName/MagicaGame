namespace Magica.Objects.Units.Skills.AttackSkills
{
    /// <summary>
    /// Abstract class that represents all the attack skills in the game.
    /// </summary>
    internal abstract class AttackSkill : Skill
    {
        private int dmg;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttackSkill"/> class.
        /// </summary>
        /// <param name="dmg">An amount of the damage that the skill does.</param>
        /// <param name="asset">An array that contains the appearance of the skill.</param>
        /// <param name="name">A name of the skill.</param>
        /// <param name="manaCost">An amount of the manacost of the skill.</param>
        public AttackSkill(int dmg, string[] asset, string name, int manaCost)
            : base(asset, name, manaCost)
        {
            this.dmg = dmg;
        }

        /// <summary>
        /// Gets an amount of the damage that the skill does.
        /// </summary>
        public int Dmg
        {
            get
            {
                return this.dmg;
            }
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
                target.CurrentHp -= caster.Dmg + this.dmg;
                return true;
            }

            return false;
        }
    }
}
