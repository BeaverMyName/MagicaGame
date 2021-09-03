using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Objects.Units;

namespace Magica.Items.ConsumableItems
{
    /// <summary>
    /// Class that represents all consumable items in the game
    /// </summary>
    /// <typeparam name="T">Hero if item is positive and Monser if - negative</typeparam>
    class ConsumableItem<T> : Item where T : Unit
    {
        private UnitStateChanger itemEffect;

        public UnitStateChanger ItemEffect
        {
            get
            {
                return itemEffect;
            }
        }

        public ConsumableItem(string name, UnitStateChanger effect) : base (name) 
        {
            itemEffect = effect;        
        }

        public virtual void DoEffect(T unit) 
        {
            unit.UnitState += ItemEffect;
        }
    }
}
