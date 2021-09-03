using Magica.Interfaces;

namespace Magica.Items.Weapons
{
    /// <summary>
    /// Class that represents all the staffs in the game.
    /// </summary>
    internal class Staff : Weapon
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Staff"/> class.
        /// </summary>
        /// <param name="name">A name of the staff.</param>
        /// <param name="dmg">An amound of the damage that the staff does.</param>
        /// <param name="skills">An array of the skill that that staff does.</param>
        public Staff(string name, int dmg, params ISkill[] skills)
            : base(name, dmg, skills)
        {
        }
    }
}
