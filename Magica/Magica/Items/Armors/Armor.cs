using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Objects.Units.Skills;
using Magica.Interfaces;

namespace Magica.Items.Armors
{
    /// <summary>
    /// Class that represents all armor equipments. Item should inherit the Armor class if it is an armor equipment.
    /// </summary>
    class Armor : Item
    {
        private int defence;
        private ISkill[] skills;
        
        public int Defence
        {
            get
            {
                return defence;
            }
        }

        public ISkill[] Skills
        {
            get
            {
                return skills;
            }
        }

        public Armor(string name, int defence, params ISkill[] skills) : base(name)
        {
            this.defence = defence;
            this.skills = skills;
        }

        public override string ToString()
        {
            return base.ToString() + $" - def: {defence}";
        }
    }
}
