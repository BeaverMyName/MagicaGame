using Magica.Interfaces;

namespace Magica.Items.Weapons
{
    /// <summary>
    /// Class that represents all the swords in the game.
    /// </summary>
    internal class Sword : Weapon
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sword"/> class.
        /// </summary>
        /// <param name="name">A name of the sword.</param>
        /// <param name="dmg">An amound of the damage that the sword does.</param>
        /// <param name="skills">An array of the skills that the sword does.</param>
        public Sword(string name, int dmg, params ISkill[] skills)
            : base(name, dmg, skills)
        {
        }
    }
}
