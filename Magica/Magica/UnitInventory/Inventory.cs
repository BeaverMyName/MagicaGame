using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Items;
using Magica.Interfaces;
using Magica.Items.Weapons;
using Magica.Objects.Units;
using Magica.Items.Armors;
using Magica.Items.ConsumableItems;

namespace Magica.UnitInventory
{
    /// <summary>
    /// Class that represents invetory of the unit. Inactive items.
    /// </summary>
    class Inventory
    {
        /// <summary>
        /// Array of all inactive items in the unit inventory.
        /// </summary>
        private IItem[] unitInventory;

        public IItem[] UnitInventory
        {
            get
            {
                return unitInventory;
            }
            set
            {
                unitInventory = value;
            }
        }

        public Inventory(params IItem[] inventory)
        {
            this.unitInventory = inventory;
        }

        /// <summary>
        /// Change inventory of the unit or chest.
        /// </summary>
        /// <param name="add">true: add items to the inventory
        /// false: remove items from the inventory</param>
        /// <param name="items">Items that you want to add or remove</param>
        public void ChangeInventory(bool add, params IItem[] items)
        {
            if (add)
            {
                IItem[] temp = unitInventory;
                unitInventory = new IItem[unitInventory.Length + items.Length];
                for(int i = 0; i < unitInventory.Length; i++)
                {
                    if (i < temp.Length)
                        unitInventory[i] = temp[i];
                    else
                        unitInventory[i] = items[i - temp.Length];
                }
            }
            else
            {
                IItem[] temp = unitInventory;
                byte step = 0;
                unitInventory = new IItem[unitInventory.Length - 1];
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] == items[0] && step == 0)
                    {
                        step = 1;
                        continue;
                    }
                    else
                    {
                        unitInventory[i - step] = temp[i];
                    }
                        
                }
            }
        }

        /// <summary>
        /// Method to switch equipment or use consumable items.
        /// </summary>
        /// <param name="hero">Current hero</param>
        /// <param name="monster">Target of negative consumable items</param>
        public void ManageInventory(Unit hero, Unit monster = null)
        {
            int pointer = 0;
            while (true)
            {
                DisplayInventory(pointer);
                hero.Equipment.DisplayEquipment();
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if(pointer > 0)
                            pointer -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (pointer < unitInventory.Length - 1)
                            pointer += 1;
                        break;
                    case ConsoleKey.Enter:
                        if(unitInventory[pointer] is PositiveConsumableItem)
                        {
                            (unitInventory[pointer] as PositiveConsumableItem).DoEffect(hero as Hero);
                            ChangeInventory(false, unitInventory[pointer]);
                            
                        }
                        else if(unitInventory[pointer] is NegativeConsumableItem && monster != null)
                        {
                            (unitInventory[pointer] as NegativeConsumableItem).DoEffect(monster as Monster);
                            ChangeInventory(false, unitInventory[pointer]);
                        }
                        else if(unitInventory[pointer] is Weapon)
                        {
                            (unitInventory[pointer], hero.Equipment.Weapon) = (hero.Equipment.Weapon, unitInventory[pointer] as Weapon);
                        }
                        else if(unitInventory[pointer] is Armor)
                        {
                            (unitInventory[pointer], hero.Equipment.Armor) = (hero.Equipment.Armor, unitInventory[pointer] as Armor);
                        }

                        if (pointer == unitInventory.Length) pointer--;
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
            for(int i = 0; i < unitInventory.Length; i++)
            {
                if (menu == i)
                    Console.Write("-> ");
                Console.WriteLine(unitInventory[i].ToString());
            }
        }
    }
}
