using Magica.Interfaces;
using System;
using Magica.Battles;
using Magica.UnitInventory;
using Magica.Equipments;
using Magica.GameAssets;

namespace Magica.Objects.Units
{
    /// <summary>
    /// Class that represents all the monsters in the game.
    /// </summary>
    internal class Monster : Unit
    {
        private string[] image = Assets.Vampire;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monster"/> class.
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
        public Monster(string name, int maxHp, int maxMp, int dmg, int y, int x, Inventory inventory, Equipment equipment, ConsoleColor color = ConsoleColor.Red)
            : base(name, maxHp, maxMp, dmg, y, x, 'X', inventory, equipment, color)
        {
        }

        /// <summary>
        /// Gets an array that contains an appearance of the monster in the battle.
        /// </summary>
        public string[] Image
        {
            get
            {
                return this.image;
            }
        }

        /// <summary>
        /// Moves the unit.
        /// </summary>
        /// <param name="field">A current level.</param>
        public override void Move(IField field)
        {
            Hero hero = this.CheckCollisionAround(field, typeof(Hero), ConsoleColor.Yellow) as Hero;
            if (hero != null)
            {
                Battle battle = new Battle(hero, this);
                battle.PlayBattle(field);
            }

            base.Move(field);
        }
    }
}
