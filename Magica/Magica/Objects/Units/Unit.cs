using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Interfaces;
using Magica.Objects.Environment;
using Magica.UnitInventory;
using Magica.Equipments;
using Magica.Objects.Units.Skills;

namespace Magica.Objects.Units
{
    /// <summary>
    /// Delegate that represents unit state. Can contains states like OnFire, Bleeding, etc.
    /// </summary>
    /// <param name="target">Unit that takes the effect</param>
    internal delegate void UnitStateChanger(Unit target);

    /// <summary>
    /// Class that represents all live units on the level
    /// </summary>
    abstract class Unit : GameObject, IMovable
    {
        private string name;
        private int maxHp;
        private int maxMp;
        private int currentHp;
        private int currentMp;
        private int dmg;
        private Inventory inventory;
        private Equipment equipment;
        private ISkill[] skills;
        private UnitStateChanger unitState;
        private bool haveMoved;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int MaxHp
        {
            get
            {
                return maxHp;
            }
            set
            {
                maxHp = value;
            }
        }

        public int MaxMp
        {
            get
            {
                return maxMp;
            }
            set
            {
                maxMp = value;
            }
        }

        public int CurrentHp
        {
            get
            {
                return currentHp;
            }
            set
            {
                currentHp = value;
            }
        }

        public int CurrentMp
        {
            get
            {
                return currentMp;
            }
            set
            {
                currentMp = value;
            }
        }

        public int Dmg
        {
            get
            {
                return dmg + equipment.Weapon.Dmg;
            }
            set
            {
                dmg = value;
            }
        }

        public UnitStateChanger UnitState
        {
            get
            {
                return unitState;
            }
            set
            {
                unitState = value;
            }
        }

        public ISkill[] Skills
        {
            get
            {
                skills = new ISkill[equipment.Weapon.Skills.Length + equipment.Armor.Skills.Length + 1];
                for(int i = 0; i < equipment.Weapon.Skills.Length; i++)
                {
                    skills[i] = equipment.Weapon.Skills[i];
                }
                for(int i = 0; i < equipment.Armor.Skills.Length; i++)
                {
                    skills[i + equipment.Weapon.Skills.Length] = equipment.Armor.Skills[i];
                }

                skills[equipment.Weapon.Skills.Length + equipment.Armor.Skills.Length] = new InventorySkill();
                return skills;
            }
            
        }

        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;
            }
        }

        public Equipment Equipment
        {
            get
            {
                return equipment;
            }
            set
            {
                equipment = value;
            }
        }

        public bool HaveMoved
        {
            get
            {
                return haveMoved;
            }
            set
            {
                haveMoved = value;
            }
        }

        public Unit(string name, int maxHp, int maxMp, int dmg, int y, int x, char symbol, Inventory inventory, Equipment equipment, ConsoleColor color) : base (y, x, symbol, color)
        {
            this.name = name;
            this.maxHp = maxHp;
            this.maxMp = maxMp;
            this.currentHp = this.maxHp;
            this.currentMp = this.maxMp;
            this.dmg = dmg;
            this.inventory = inventory;
            this.equipment = equipment;
            this.haveMoved = false;
        }

        /// <summary>
        /// Move the unit.
        /// </summary>
        /// <param name="field">Current level</param>
        public virtual void Move(IField field)
        {
            haveMoved = true;
        }

        /// <summary>
        /// Check unit collision with the specific object
        /// </summary>
        /// <param name="obj">Specific object</param>
        /// <param name="type">Type of the specific object</param>
        /// <returns></returns>
        public bool CheckCollizion(IObject obj, Type type)
        {
            return obj.GetType() == type ? true : false;
        }

        /// <summary>
        /// Check specific object around the unit
        /// </summary>
        /// <param name="field">Current level</param>
        /// <param name="type">Type of the specific object</param>
        /// <returns></returns>
        public IObject CheckCollizionAround(IField field, Type type, ConsoleColor color)
        {
            for (int i = Y - 1; i < Y + 2; i++)
            {
                for (int j = X - 1; j < X + 2; j++)
                {  
                    if (!(i == Y && j == X) && CheckCollizion(field.Field[i, j], type) && field.Field[i, j].Color == color)
                    {
                        return field.Field[i, j];
                    }
                }  
            }
            return null;
        }
    }
}
