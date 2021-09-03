using Magica.Interfaces;

namespace Magica.Items.Weapons
{
    /// <summary>
    /// Class that represents all weapon equipments. Item should inherit the Weapon class if it is an weapon equipment.
    /// </summary>
    internal class Weapon : Item
    {
        private int dmg;
        private ISkill[] skills;

        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        /// <param name="name">A name of the weapon.</param>
        /// <param name="dmg">An amount of the damage that the weapon does.</param>
        /// <param name="skills">An array of the skills that the weapon does.</param>
        public Weapon(string name, int dmg, params ISkill[] skills)
            : base(name)
        {
            this.dmg = dmg;
            this.skills = skills;
        }

        /// <summary>
        /// Gets an amount of the damage that the weapon does.
        /// </summary>
        public int Dmg
        {
            get
            {
                return this.dmg;
            }
        }

        /// <summary>
        /// Gets an array of the skills that the weapon does.
        /// </summary>
        public ISkill[] Skills
        {
            get
            {
                return this.skills;
            }
        }

        /// <summary>
        /// Returns a string with all characteristics of the weapon.
        /// </summary>
        /// <returns>A string with all characteristics of the weapon.</returns>
        public override string ToString()
        {
            return base.ToString() + $" - dmg: {this.dmg}";
        }
    }
}
