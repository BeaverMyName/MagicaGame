using Magica.Interfaces;
using Magica.Battles;

namespace Magica.Objects.Units.Skills
{
    /// <summary>
    /// Abstract class that represents all the skills in the game.
    /// </summary>
    internal abstract class Skill : ISkill
    {
        private readonly string[] asset;
        private readonly string name;
        private readonly int manaCost;

        /// <summary>
        /// Initializes a new instance of the <see cref="Skill"/> class.
        /// </summary>
        /// <param name="asset">An array that contains the appearance of the skill.</param>
        /// <param name="name">A name of the skill.</param>
        /// <param name="manaCost">An amount of the manacost of the skill.</param>
        public Skill(string[] asset, string name, int manaCost)
        {
            this.asset = asset;
            this.name = name;
            this.manaCost = manaCost;
        }

        /// <summary>
        /// Gets an array that contains the appearance of the skill.
        /// </summary>
        public string[] Asset
        {
            get
            {
                return this.asset;
            }
        }

        /// <summary>
        /// Gets a name of the skill.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets an amount of the manacost of the skill.
        /// </summary>
        public int ManaCost
        {
            get
            {
                return this.manaCost;
            }
        }

        /// <summary>
        /// Does an action of the skill.
        /// </summary>
        /// <param name="caster">Unit that casts the skill.</param>
        /// <param name="target">Unit that takes the effect of the skill.</param>
        /// <returns>Whether caster has enough mana to cast the skill.</returns>
        public virtual bool DoAction(Unit caster, Unit target)
        {
            if (caster.CurrentMp < this.manaCost)
            {
                Battle.ChangeLog($"{caster.Name}: Not enough mana");
                return false;
            }

            caster.CurrentMp -= this.manaCost;
            return true;
        }
    }
}
