using System;
using Magica.Interfaces;
using Magica.Items.Weapons;
using Magica.Objects.Units;
using Magica.Items.Armors;
using Magica.Items.ConsumableItems;

namespace Magica.UnitInventory
{
    /// <summary>
    /// Class that represents the invetories of the units. Contains the inactive items.
    /// </summary>
    internal class Inventory
    {
        private IItem[] unitInventory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory"/> class.
        /// </summary>
        /// <param name="inventory">An array that contains all the items in the inventory.</param>
        public Inventory(params IItem[] inventory)
        {
            this.unitInventory = inventory;
        }

        /// <summary>
        /// Gets or sets an array that contains all the items in the inventory.
        /// </summary>
        public IItem[] UnitInventory
        {
            get
            {
                return this.unitInventory;
            }

            set
            {
                this.unitInventory = value;
            }
        }

        /// <summary>
        /// Changes the inventory of the unit.
        /// </summary>
        /// <param name="add">true: adds the items to the inventory;
        /// false: removes the items from the inventory.</param>
        /// <param name="items">Items that you want to add or remove.</param>
        public void ChangeInventory(bool add, params IItem[] items)
        {
            if (add)
            {
                IItem[] temp = this.unitInventory;
                this.unitInventory = new IItem[this.unitInventory.Length + items.Length];
                for (int i = 0; i < this.unitInventory.Length; i++)
                {
                    if (i < temp.Length)
                    {
                        this.unitInventory[i] = temp[i];
                    }
                    else
                    {
                        this.unitInventory[i] = items[i - temp.Length];
                    }
                }
            }
            else
            {
                IItem[] temp = this.unitInventory;
                byte step = 0;
                this.unitInventory = new IItem[this.unitInventory.Length - 1];
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] == items[0] && step == 0)
                    {
                        step = 1;
                        continue;
                    }
                    else
                    {
                        this.unitInventory[i - step] = temp[i];
                    }
                }
            }
        }

        /// <summary>
        /// Switches equipment or uses consumables.
        /// </summary>
        /// <param name="hero">A current hero.</param>
        /// <param name="monster">A target of the negative consumable items.</param>
        public void ManageInventory(Unit hero, Unit monster = null)
        {
            int pointer = 0;
            while (true)
            {
                this.DisplayInventory(pointer);
                hero.Equipment.DisplayEquipment();
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (pointer > 0)
                        {
                            pointer -= 1;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (pointer < this.unitInventory.Length - 1)
                        {
                            pointer += 1;
                        }

                        break;
                    case ConsoleKey.Enter:
                        if (this.unitInventory[pointer] is PositiveConsumableItem)
                        {
                            (this.unitInventory[pointer] as PositiveConsumableItem).DoEffect(hero as Hero);
                            this.ChangeInventory(false, this.unitInventory[pointer]);
                        }
                        else if (this.unitInventory[pointer] is NegativeConsumableItem && monster != null)
                        {
                            (this.unitInventory[pointer] as NegativeConsumableItem).DoEffect(monster as Monster);
                            this.ChangeInventory(false, this.unitInventory[pointer]);
                        }
                        else if (this.unitInventory[pointer] is Weapon)
                        {
                            (this.unitInventory[pointer], hero.Equipment.Weapon) = (hero.Equipment.Weapon, this.unitInventory[pointer] as Weapon);
                        }
                        else if (this.unitInventory[pointer] is Armor)
                        {
                            (this.unitInventory[pointer], hero.Equipment.Armor) = (hero.Equipment.Armor, this.unitInventory[pointer] as Armor);
                        }

                        if (pointer == this.unitInventory.Length)
                        {
                            pointer--;
                        }

                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        private void DisplayInventory(int menu)
        {
            Console.Clear();
            Console.WriteLine("INVENTORY\n");
            for (int i = 0; i < this.unitInventory.Length; i++)
            {
                if (menu == i)
                {
                    Console.Write("-> ");
                }

                Console.WriteLine(this.unitInventory[i].ToString());
            }
        }
    }
}
