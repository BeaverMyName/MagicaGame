using Magica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Battles;
using Magica.UnitInventory;
using Magica.Equipments;
using Magica.GameAssets;

namespace Magica.Objects.Units
{
    class Monster : Unit
    {
        private string[] image = Assets.Vampire;
        public string[] Image { get { return image; } }

        public Monster(string name, int maxHp, int maxMp, int dmg, int y, int x, Inventory inventory, Equipment equipment, ConsoleColor color = ConsoleColor.Red) : base(name, maxHp, maxMp, dmg, y, x, 'X', inventory, equipment, color) 
        {
            
        }

        public override void Move(IField field)
        {
            Hero hero = CheckCollizionAround(field, typeof(Hero), ConsoleColor.Yellow) as Hero;
            if(hero != null)
            {
                Battle battle = new Battle(hero, this);
                battle.PlayBattle(field);
            }

            base.Move(field);
        }
    }
}
