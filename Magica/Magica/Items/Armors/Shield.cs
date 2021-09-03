using Magica.Interfaces;

namespace Magica.Items.Armors
{
    /// <summary>
    /// Class that represents all the shields in the game.
    /// </summary>
    internal class Shield : Armor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shield"/> class.
        /// </summary>
        /// <param name="name">A name of the shield.</param>
        /// <param name="defence">An amount of the defence.</param>
        /// <param name="skills">An array of the skills.</param>
        public Shield(string name, int defence, params ISkill[] skills)
            : base(name, defence, skills)
        {
        }
    }
}
