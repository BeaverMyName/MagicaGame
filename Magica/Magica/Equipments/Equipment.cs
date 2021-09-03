using System;
using Magica.Items.Weapons;
using Magica.Items.Armors;

namespace Magica.Equipments
{
    /// <summary>
    /// Class that represents active equipment of the unit.
    /// </summary>
    internal class Equipment
    {
        private Weapon weapon;
        private Armor armor;

        /// <summary>
        /// Gets or sets active weapon of the unit.
        /// </summary>
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

        /// <summary>
        /// Gets or sets active armor of the unit.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Equipment"/> class.
        /// </summary>
        /// <param name="weapon">Active weapon.</param>
        /// <param name="armor">Active armor.</param>
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
            Console.WriteLine($"Weapon: {this.weapon.ToString()}");
            Console.WriteLine($"Armor: {this.armor.ToString()}");
        }
    }
}
