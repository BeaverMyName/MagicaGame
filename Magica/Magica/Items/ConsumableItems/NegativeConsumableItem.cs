using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Objects.Units;

namespace Magica.Items.ConsumableItems
{
    class NegativeConsumableItem : ConsumableItem<Monster>
    {
        private int dmg;

        public int Dmg
        {
            get
            {
                return dmg;
            }
        }

        public NegativeConsumableItem(string name, UnitStateChanger effect, int dmg) : base (name, effect) 
        {
            this.dmg = dmg;
        }

        public override void DoEffect(Monster unit)
        {
            base.DoEffect(unit);
            unit.CurrentHp -= dmg;
        }
    }
}
