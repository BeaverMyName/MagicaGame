using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Items.Weapons;
using Magica.Items.Armors;

namespace Magica.Equipments
{
    /// <summary>
    /// Class that represents active equipment of the unit.
    /// </summary>
    class Equipment
    {
        private Weapon weapon;
        private Armor armor;

        public Weapon Weapon
        {
            get
            {
                return weapon;
            }
            set
            {
                weapon = value;
            }
        }

        public Armor Armor
        {
            get
            {
                return armor;
            }
            set
            {
                armor = value;
            }
        }

        public Equipment(Weapon weapon, Armor armor)
        {
            this.weapon = weapon;
            this.armor = armor;
        }

        /// <summary>
        /// Display the hero equipment
        /// </summary>
        public void DisplayEquipment()
        {
            Console.WriteLine("\nEQUIPMENT\n");
            Console.WriteLine($"Weapon: {weapon.ToString()}");
            Console.WriteLine($"Armor: {armor.ToString()}");
        }
    }
}
