using System;
using Magica.Interfaces;
using Magica.Objects.Units;
using Magica.Levels;
using Magica.Menus;
using Magica.Battles;
using Magica.UnitInventory;
using Magica.Items.Weapons;
using Magica.Items.Armors;
using Magica.Equipments;
using Magica.Objects.Units.Skills;
using Magica.GameAssets;
using Magica.Objects.Units.Skills.AttackSkills;
using Magica.Objects.Units.Skills.DefenceSkills;
using Magica.Objects.Environment;


namespace Magica.GameFolder
{
    /// <summary>
    /// Class that contains all game objects and levels in the game.
    /// </summary>
    static class Game
    {
        private static IField currentLevel;
        private static Hero hero;
        private static Menu gameMenu;
        private static Inventory starterPackInventory;
        private static Equipment starterPackEquipment;

        static Game()
        {
            starterPackInventory = new Inventory(ItemExamples.smallHP, ItemExamples.smallHP, ItemExamples.molotov);
            starterPackEquipment = new Equipment(ItemExamples.woodSword, ItemExamples.woodShield);
            gameMenu = new Menu(new string[] { "Move", "Attack", "Open", "Inventory" });
            currentLevel = LevelExamples.dungeon1;
            hero = new Hero("Paladin", 100, 20, 10, currentLevel.Field.GetLength(0) - 2, 1, starterPackInventory, starterPackEquipment, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Start the game
        /// </summary>
        public static void StartGame()
        {
            currentLevel.Field[currentLevel.Field.GetLength(0) - 2, 1] = hero;
            while (true)
            {
                Turn();
            }
        }

        /// <summary>
        /// Method that contains whole procces of the turn.
        /// </summary>
        private static void Turn()
        {
            int menu = 0;

            while (true)
            {
                currentLevel.DisplayField();
                gameMenu.DisplayMenu(menu);

                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if(menu != 0)
                            menu -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (menu != gameMenu.Items.Length - 1)
                            menu += 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (menu)
                        {
                            case 0:
                                IMovable obj;
                                for (int i = 0; i < currentLevel.Field.GetLength(0); i++)
                                {
                                    for (int j = 0; j < currentLevel.Field.GetLength(1); j++)
                                    {
                                        obj = currentLevel.Field[i, j] as IMovable;
                                        if(obj != null && !obj.HaveMoved)
                                            obj?.Move(currentLevel);
                                    }
                                }
                                for (int i = 0; i < currentLevel.Field.GetLength(0); i++)
                                {
                                    for (int j = 0; j < currentLevel.Field.GetLength(1); j++)
                                    {
                                        obj = currentLevel.Field[i, j] as IMovable;
                                        if (obj != null)
                                            obj.HaveMoved = false;
                                    }
                                }
                                break;
                            case 1:
                                Monster monster = hero.CheckCollizionAround(currentLevel, typeof(Monster), ConsoleColor.Red) as Monster;
                                Battle battle;
                                if (monster != null)
                                {
                                    battle = new Battle(hero, monster);
                                    battle.PlayBattle(currentLevel);
                                }
                                break;
                            case 2:
                                Chest chest = hero.CheckCollizionAround(currentLevel, typeof(Chest), ConsoleColor.Green) as Chest;
                                chest?.Open(hero);
                                IObject door = hero.CheckCollizionAround(currentLevel, typeof(Door), ConsoleColor.Green) as Door;
                                if(door != null)
                                {
                                    currentLevel.Field[door.Y, door.X] = new Floor(door.Y, door.X);
                                }
                                break;
                            case 3:
                                hero.Inventory.ManageInventory(hero);
                                break;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Finish the game
        /// </summary>
        public static void GameOver()
        {
            Environment.Exit(0);
        }
    }
}
