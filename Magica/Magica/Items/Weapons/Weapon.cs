using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Objects.Units.Skills;
using Magica.Interfaces;

namespace Magica.Items.Weapons
{
    /// <summary>
    /// Class that represents all weapon equipments. Item should inherit the Weapon class if it is an weapon equipment.
    /// </summary>
    class Weapon : Item
    {
        private int dmg;
        private ISkill[] skills;
        
        public int Dmg
        {
            get
            {
                return dmg;
            }
        }

        public ISkill[] Skills
        {
            get
            {
                return skills;
            }
        }

        public Weapon(string name, int dmg, params ISkill[] skills) : base (name)
        {
            this.dmg = dmg;
            this.skills = skills;
        }

        public override string ToString()
        {
            return base.ToString() + $" - dmg: {dmg}";
        }
    }
}
