using Magica.Interfaces;

namespace Magica.Items.Armors
{
    /// <summary>
    /// Class that represents all armor equipments. Item should inherit the Armor class if it is an armor equipment.
    /// </summary>
    internal class Armor : Item
    {
        private int defence;
        private ISkill[] skills;

        /// <summary>
        /// Initializes a new instance of the <see cref="Armor"/> class.
        /// </summary>
        /// <param name="name">A name of the armor.</param>
        /// <param name="defence">An amount of the defence.</param>
        /// <param name="skills">An array of the skills.</param>
        public Armor(string name, int defence, params ISkill[] skills)
            : base(name)
        {
            this.defence = defence;
            this.skills = skills;
        }

        /// <summary>
        /// Gets an amount of the defence.
        /// </summary>
        public int Defence
        {
            get
            {
                return this.defence;
            }
        }

        /// <summary>
        /// Gets an array of the skills of the armor.
        /// </summary>
        public ISkill[] Skills
        {
            get
            {
                return this.skills;
            }
        }

        /// <summary>
        /// Returns a string with all characteristics of the armor.
        /// </summary>
        /// <returns>A string with all characteristics of the armor.</returns>
        public override string ToString()
        {
            return base.ToString() + $" - def: {this.defence}";
        }
    }
}
