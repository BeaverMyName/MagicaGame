using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.GameAssets;

namespace Magica.Objects.Units.Skills
{
    class InventorySkill : Skill
    {
        public InventorySkill() : base(Assets.Inventory, "Inventory", 0) { }

        public override bool Action(Unit caster, Unit target)
        {
            caster.Inventory.ManageInventory(caster, target);
            return true;
        }
    }
}
