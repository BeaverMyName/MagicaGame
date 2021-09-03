using Magica.GameAssets;

namespace Magica.Objects.Units.Skills
{
    /// <summary>
    /// Class that represents the inventory skill.
    /// </summary>
    internal class InventorySkill : Skill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventorySkill"/> class.
        /// </summary>
        public InventorySkill()
            : base(Assets.Inventory, "Inventory", 0)
        {
        }

        /// <summary>
        /// Does an action of the skill.
        /// </summary>
        /// <param name="caster">Unit that casts the inventory skill.</param>
        /// <param name="target">Unit that takes the effect of the inventory skill.</param>
        /// <returns>Whether caster has enough mana to cast the inventory skill.</returns>
        public override bool DoAction(Unit caster, Unit target)
        {
            caster.Inventory.ManageInventory(caster, target);
            return true;
        }
    }
}
