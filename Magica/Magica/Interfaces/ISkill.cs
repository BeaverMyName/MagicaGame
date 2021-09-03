using Magica.Objects.Units;

namespace Magica.Interfaces
{
    /// <summary>
    /// All skills in the game must implement the interface ISkill.
    /// </summary>
    internal interface ISkill
    {
        /// <summary>
        /// Gets an appearance of the skill in the battle.
        /// </summary>
        public string[] Asset { get; }

        /// <summary>
        /// Gets a name of the skill.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a manacost of the skill.
        /// </summary>
        public int ManaCost { get; }

        /// <summary>
        /// Does an action of the skill.
        /// </summary>
        /// <param name="caster">A unit that casts the skill.</param>
        /// <param name="target">A unit that takes an effect of the skill.</param>
        /// <returns>Whether unit has enough mana to cast the spell.</returns>
        public bool DoAction(Unit caster, Unit target);
    }
}
