using System;
using Magica.Interfaces;
using Magica.UnitInventory;
using Magica.Equipments;
using Magica.Objects.Units.Skills;

namespace Magica.Objects.Units
{
    /// <summary>
    /// Delegate that represents the unit state.
    /// </summary>
    /// <param name="target">A unit that takes the effect.</param>
    internal delegate void UnitStateChanger(Unit target);

    /// <summary>
    /// Class that represents all the live units in the game.
    /// </summary>
    internal abstract class Unit : GameObject, IMovable
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class.
        /// </summary>
        /// <param name="name">A name.</param>
        /// <param name="maxHp">A maximum of hp.</param>
        /// <param name="maxMp">A maximum of mp.</param>
        /// <param name="dmg">An amount of the damage that the unit does.</param>
        /// <param name="y">A vertical position on the level.</param>
        /// <param name="x">A gorizontal position on the level.</param>
        /// <param name="symbol">An appearance on the level.</param>
        /// <param name="inventory">An inventory.</param>
        /// <param name="equipment">An equipment.</param>
        /// <param name="color">A color on the level.</param>
        public Unit(string name, int maxHp, int maxMp, int dmg, int y, int x, char symbol, Inventory inventory, Equipment equipment, ConsoleColor color)
            : base(y, x, symbol, color)
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
        /// Gets a name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets or sets a maximum of hp.
        /// </summary>
        public int MaxHp
        {
            get
            {
                return this.maxHp;
            }

            set
            {
                this.maxHp = value;
            }
        }

        /// <summary>
        /// Gets or sets a maximum of mp.
        /// </summary>
        public int MaxMp
        {
            get
            {
                return this.maxMp;
            }

            set
            {
                this.maxMp = value;
            }
        }

        /// <summary>
        /// Gets or sets a current hp.
        /// </summary>
        public int CurrentHp
        {
            get
            {
                return this.currentHp;
            }

            set
            {
                this.currentHp = value;
            }
        }

        /// <summary>
        /// Gets or sets a current mp.
        /// </summary>
        public int CurrentMp
        {
            get
            {
                return this.currentMp;
            }

            set
            {
                this.currentMp = value;
            }
        }

        /// <summary>
        /// Gets or sets an amount of the damage that the unit does.
        /// </summary>
        public int Dmg
        {
            get
            {
                return this.dmg + this.equipment.Weapon.Dmg;
            }

            set
            {
                this.dmg = value;
            }
        }

        /// <summary>
        /// Gets or sets delegate that contains the unit state.
        /// </summary>
        public UnitStateChanger UnitState
        {
            get
            {
                return this.unitState;
            }

            set
            {
                this.unitState = value;
            }
        }

        /// <summary>
        /// Gets an array of the unit skills.
        /// </summary>
        public ISkill[] Skills
        {
            get
            {
                this.skills = new ISkill[this.equipment.Weapon.Skills.Length + this.equipment.Armor.Skills.Length + 1];
                for (int i = 0; i < this.equipment.Weapon.Skills.Length; i++)
                {
                    this.skills[i] = this.equipment.Weapon.Skills[i];
                }

                for (int i = 0; i < this.equipment.Armor.Skills.Length; i++)
                {
                    this.skills[i + this.equipment.Weapon.Skills.Length] = this.equipment.Armor.Skills[i];
                }

                this.skills[this.equipment.Weapon.Skills.Length + this.equipment.Armor.Skills.Length] = new InventorySkill();
                return this.skills;
            }
        }

        /// <summary>
        /// Gets or sets an inventory.
        /// </summary>
        public Inventory Inventory
        {
            get
            {
                return this.inventory;
            }

            set
            {
                this.inventory = value;
            }
        }

        /// <summary>
        /// Gets or sets an equipment.
        /// </summary>
        public Equipment Equipment
        {
            get
            {
                return this.equipment;
            }

            set
            {
                this.equipment = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the unit has moved.
        /// </summary>
        public bool HaveMoved
        {
            get
            {
                return this.haveMoved;
            }

            set
            {
                this.haveMoved = value;
            }
        }

        /// <summary>
        /// Moves the unit.
        /// </summary>
        /// <param name="field">A current level.</param>
        public virtual void Move(IField field)
        {
            this.haveMoved = true;
        }

        /// <summary>
        /// Checks whether the collision object is a specific type.
        /// </summary>
        /// <param name="obj">Checkable object.</param>
        /// <param name="type">Specific type.</param>
        /// <param name="implement">A name of the interface that the object implements.</param>
        /// <returns>Whether the collision object is a specific type.</returns>
        public bool CheckCollision(IObject obj, Type type, string implement = "unknown")
        {
            return obj.GetType() == type ? true : false || obj.GetType().GetInterface(implement) == type ? true : false;
        }

        /// <summary>
        /// Finds an object around the unit.
        /// </summary>
        /// <param name="field">Current level.</param>
        /// <param name="type">Specific type.</param>
        /// <param name="color">Color of the object.</param>
        /// <param name="implement">A name of the interface that the object implements.</param>
        /// <returns>An object with the specific type or null.</returns>
        public IObject CheckCollisionAround(IField field, Type type, ConsoleColor color, string implement = "unknown")
        {
            for (int i = this.Y - 1; i < this.Y + 2; i++)
            {
                for (int j = this.X - 1; j < this.X + 2; j++)
                {
                    if (!(i == this.Y && j == this.X) && this.CheckCollision(field.Field[i, j], type, implement) && field.Field[i, j].Color == color)
                    {
                        return field.Field[i, j];
                    }
                }
            }

            return null;
        }
    }
}
