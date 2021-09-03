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
        public Hero(string name, int maxHp, int maxMp, int dmg, int y, int x, Inventory inventory, Equipment equipments, ConsoleColor color) : base(name, maxHp, maxMp, dmg, y, x, 'O', inventory, equipments, color) { }

        public override void Move(IField field)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (CheckCollision(field.Field[Y - 1, X], typeof(Floor)))
                    {
                        field.Field[Y, X] = new Floor(Y, X);
                        Y -= 1;
                        field.Field[Y, X] = this;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CheckCollision(field.Field[Y + 1, X], typeof(Floor)))
                    {
                        field.Field[Y, X] = new Floor(Y, X);
                        Y += 1;
                        field.Field[Y, X] = this;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (CheckCollision(field.Field[Y, X - 1], typeof(Floor)))
                    {
                        field.Field[Y, X] = new Floor(Y, X);
                        X -= 1;
                        field.Field[Y, X] = this;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (CheckCollision(field.Field[Y, X + 1], typeof(Floor)))
                    {
                        field.Field[Y, X] = new Floor(Y, X);
                        X += 1;
                        field.Field[Y, X] = this;
                    }
                    break;
            }

            base.Move(field);
        }
    }
}
