using System;
using Magica.Interfaces;
using Magica.Levels;
using Magica.Objects.Environment;
using Magica.Objects.Environment.Walls;
using Magica.UnitInventory;
using Magica.Equipments;
using Magica.Objects.Units;
using Magica.Items.ConsumableItems;

namespace Magica.GameAssets
{
    /// <summary>
    /// Class that contains examples of the levels.
    /// </summary>
    internal static class LevelExamples
    {
        /// <summary>
        /// Initializes static members of the <see cref="LevelExamples"/> class.
        /// </summary>
        static LevelExamples()
        {
            Dungeon1 = new Dungeon(20, 20, new IObject[] {
            #region Room10
            new VerticalWall(1, 7),
            new VerticalWall(3, 7),
            new VerticalWall(4, 7),
            new GorizontalWall(4, 1),
            new GorizontalWall(4, 2),
            new GorizontalWall(4, 3),
            new GorizontalWall(4, 4),
            new GorizontalWall(4, 5),
            new GorizontalWall(4, 6),
            new Monster("Vampire", 200, 40, 10, 2, 4, new Inventory(new IItem[] { ItemExamples.FireStaff }), new Equipment(ItemExamples.WoodSword, ItemExamples.WoodShield)),
            new Chest(2, 1, ConsoleColor.Green, new IItem[] { ItemExamples.Molotov, ItemExamples.SmallHP }),
            #endregion
            #region Room9
            new VerticalWall(1, 11),
            new VerticalWall(2, 11),
            new VerticalWall(4, 11),
            new VerticalWall(5, 11),
            new GorizontalWall(6, 11),
            new GorizontalWall(6, 12),
            new GorizontalWall(6, 13),
            new GorizontalWall(6, 14),
            new GorizontalWall(6, 15),
            new GorizontalWall(6, 16),
            new GorizontalWall(6, 17),
            new GorizontalWall(6, 18),
                #endregion
            #region Room1
            new VerticalWall(18, 2),
            new VerticalWall(17, 2),
            new VerticalWall(16, 2),
            new GorizontalWall(15, 2),
            new GorizontalWall(15, 3),
            new Door(15, 4, ConsoleColor.Yellow),
            new GorizontalWall(15, 5),
            new GorizontalWall(15, 6),
            new VerticalWall(16, 6),
            new VerticalWall(17, 6),
            new VerticalWall(18, 6),
            new Monster("Vampire", 50, 30, 5, 16, 4, new Inventory(ItemExamples.SmallHP, new MasterKey("Master key")), new Equipment(ItemExamples.WoodSword, ItemExamples.WoodShield)),
            new Chest(18, 4, ConsoleColor.Green, ItemExamples.Katana),
                #endregion
            #region Room2
            new GorizontalWall(15, 7),
            new GorizontalWall(15, 8),
            new GorizontalWall(15, 9),
            new GorizontalWall(15, 10),
            new GorizontalWall(15, 11),
            new GorizontalWall(15, 12),
            new GorizontalWall(15, 13),
            new GorizontalWall(15, 14),
            new VerticalWall(15, 15),
            new VerticalWall(14, 15),
            new Door(13, 15, ConsoleColor.Yellow),
            new VerticalWall(12, 15),
            new GorizontalWall(11, 15),
            new GorizontalWall(11, 16),
            new GorizontalWall(11, 17),
            new GorizontalWall(11, 18),
            new Monster("Vampire", 50, 30, 5, 13, 17, new Inventory(ItemExamples.SmallHP), new Equipment(ItemExamples.WoodSword, ItemExamples.WoodShield)),
            new Monster("Vampire", 50, 30, 5, 16, 16, new Inventory(ItemExamples.SmallHP), new Equipment(ItemExamples.WoodSword, ItemExamples.WoodShield)),
            new Monster("Vampire", 50, 30, 5, 18, 18, new Inventory(ItemExamples.SmallHP), new Equipment(ItemExamples.WoodSword, ItemExamples.WoodShield)),
            new Chest(18, 7, ConsoleColor.Green, ItemExamples.Katana),
            new Chest(17, 7, ConsoleColor.Green, ItemExamples.SmallHP, ItemExamples.SmallHP),
            new Chest(16, 7, ConsoleColor.Green, ItemExamples.Molotov),
                #endregion
            });
        }

        public static IField Dungeon1 { get; set; }
    }
}
