using System;
using Magica.Objects.Units;
using Magica.Interfaces;
using Magica.Objects.Environment;

namespace Magica.Items.ConsumableItems
{
    /// <summary>
    /// Class that represents all the master keys in the game.
    /// </summary>
    internal class MasterKey : ConsumableItem<Hero>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterKey"/> class.
        /// </summary>
        /// <param name="name">A name.</param>
        public MasterKey(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Opens the clothest openable locked object.
        /// </summary>
        /// <param name="field">Current level.</param>
        /// <param name="hero">Current hero.</param>
        public void Open(IField field, Unit hero)
        {
            IOpenable obj = (field.Field[hero.Y, hero.X] as Hero).CheckCollisionAround(field, typeof(IOpenable), ConsoleColor.Yellow, "IOpenable") as IOpenable;
            if (obj != null)
            {
                obj.Open();
                hero.Inventory.ChangeInventory(false, this);
            }
        }
    }
}
