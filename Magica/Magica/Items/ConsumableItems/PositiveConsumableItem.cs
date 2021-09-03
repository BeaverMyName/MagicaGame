using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Objects.Units;

namespace Magica.Items.ConsumableItems
{
    class PositiveConsumableItem : ConsumableItem<Hero>
    {
        private int hp;

        public int Hp
        {
            get
            {
                return hp;
            }
        }

        public PositiveConsumableItem(string name, UnitStateChanger effect, int hp) : base(name, effect)
        {
            this.hp = hp;
        }

        public override void DoEffect(Hero unit)
        {
            base.DoEffect(unit);
            if (unit.CurrentHp + hp >= unit.MaxHp)
            {
                unit.CurrentHp = unit.MaxHp;
            }
            else
            {
                unit.CurrentHp += hp;
            }
        }
    }
}
