using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Interfaces;
using Magica.Objects.Environment;
using Magica.UnitInventory;
using Magica.Equipments;

namespace Magica.Objects.Units
{
    class Hero : Unit
    {
        public Hero(string name, int maxHp, int maxMp, int dmg, int y, int x, Inventory inventory, Equipment equipments, ConsoleColor color) : base(name, maxHp, maxMp, dmg, y, x, 'O', inventory, equipments, color) { }

        public override void Move(IField field)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (CheckCollizion(field.Field[Y - 1, X], typeof(Floor)))
                    {
                        field.Field[Y, X] = new Floor(Y, X);
                        Y -= 1;
                        field.Field[Y, X] = this;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CheckCollizion(field.Field[Y + 1, X], typeof(Floor)))
                    {
                        field.Field[Y, X] = new Floor(Y, X);
                        Y += 1;
                        field.Field[Y, X] = this;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (CheckCollizion(field.Field[Y, X - 1], typeof(Floor)))
                    {
                        field.Field[Y, X] = new Floor(Y, X);
                        X -= 1;
                        field.Field[Y, X] = this;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (CheckCollizion(field.Field[Y, X + 1], typeof(Floor)))
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
