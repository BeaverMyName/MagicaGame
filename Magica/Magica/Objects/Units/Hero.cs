using System;
using Magica.Interfaces;
using Magica.Objects.Environment;
using Magica.UnitInventory;
using Magica.Equipments;

namespace Magica.Objects.Units
{
    /// <summary>
    /// Class that represents all the heroes in the game.
    /// </summary>
    internal class Hero : Unit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hero"/> class.
        /// </summary>
        /// <param name="name">A name.</param>
        /// <param name="maxHp">A maximum of hp.</param>
        /// <param name="maxMp">A maximum of mp.</param>
        /// <param name="dmg">An amount of the damage that the unit does.</param>
        /// <param name="y">A vertical position on the level.</param>
        /// <param name="x">A gorizontal position on the level.</param>
        /// <param name="inventory">An inventory.</param>
        /// <param name="equipment">An equipment.</param>
        /// <param name="color">A color on the level.</param>
        public Hero(string name, int maxHp, int maxMp, int dmg, int y, int x, Inventory inventory, Equipment equipment, ConsoleColor color)
            : base(name, maxHp, maxMp, dmg, y, x, 'O', inventory, equipment, color)
        {
        }

        /// <summary>
        /// Moves the unit.
        /// </summary>
        /// <param name="field">A current level.</param>
        public override void Move(IField field)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (this.CheckCollision(field.Field[this.Y - 1, this.X], typeof(Floor)))
                    {
                        field.Field[this.Y, this.X] = new Floor(this.Y, this.X);
                        this.Y -= 1;
                        field.Field[this.Y, this.X] = this;
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (this.CheckCollision(field.Field[this.Y + 1, this.X], typeof(Floor)))
                    {
                        field.Field[this.Y, this.X] = new Floor(this.Y, this.X);
                        this.Y += 1;
                        field.Field[this.Y, this.X] = this;
                    }

                    break;
                case ConsoleKey.LeftArrow:
                    if (this.CheckCollision(field.Field[this.Y, this.X - 1], typeof(Floor)))
                    {
                        field.Field[this.Y, this.X] = new Floor(this.Y, this.X);
                        this.X -= 1;
                        field.Field[this.Y, this.X] = this;
                    }

                    break;
                case ConsoleKey.RightArrow:
                    if (this.CheckCollision(field.Field[this.Y, this.X + 1], typeof(Floor)))
                    {
                        field.Field[this.Y, this.X] = new Floor(this.Y, this.X);
                        this.X += 1;
                        field.Field[this.Y, this.X] = this;
                    }

                    break;
            }

            base.Move(field);
        }
    }
}
