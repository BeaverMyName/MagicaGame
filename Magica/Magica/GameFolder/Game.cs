﻿using System;
using Magica.Interfaces;
using Magica.Objects.Units;
using Magica.Menus;
using Magica.Battles;
using Magica.UnitInventory;
using Magica.Equipments;
using Magica.GameAssets;
using Magica.Objects.Environment;
using Magica.Items.ConsumableItems;

namespace Magica.GameFolder
{
    /// <summary>
    /// Class that contains all game objects and levels in the game.
    /// </summary>
    public static class Game
    {
        private static IField currentLevel;
        private static Hero hero;
        private static Menu gameMenu;
        private static Inventory starterPackInventory;
        private static Equipment starterPackEquipment;

        static Game()
        {
            starterPackInventory = new Inventory(ItemExamples.SmallHP, ItemExamples.SmallHP, ItemExamples.Molotov, new MasterKey("Master key"));
            starterPackEquipment = new Equipment(ItemExamples.WoodSword, ItemExamples.WoodShield);
            gameMenu = new Menu(new string[] { "Move", "Attack", "Open", "Inventory" });
            currentLevel = LevelExamples.Dungeon1;
            hero = new Hero("Paladin", 100, 20, 10, currentLevel.Field.GetLength(0) - 2, 1, starterPackInventory, starterPackEquipment, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Start the game.
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
        /// Finish the game.
        /// </summary>
        public static void GameOver()
        {
            Environment.Exit(0);
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
                        if (menu != 0)
                        {
                            menu -= 1;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (menu != gameMenu.Items.Length - 1)
                        {
                            menu += 1;
                        }

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
                                        if (obj != null && !obj.HaveMoved)
                                        {
                                            obj?.Move(currentLevel);
                                        }
                                    }
                                }

                                for (int i = 0; i < currentLevel.Field.GetLength(0); i++)
                                {
                                    for (int j = 0; j < currentLevel.Field.GetLength(1); j++)
                                    {
                                        obj = currentLevel.Field[i, j] as IMovable;
                                        if (obj != null)
                                        {
                                            obj.HaveMoved = false;
                                        }
                                    }
                                }

                                break;
                            case 1:
                                Monster monster = hero.CheckCollisionAround(currentLevel, typeof(Monster), ConsoleColor.Red) as Monster;
                                Battle battle;
                                if (monster != null)
                                {
                                    battle = new Battle(hero, monster);
                                    battle.PlayBattle(currentLevel);
                                }

                                break;
                            case 2:
                                Chest chest = hero.CheckCollisionAround(currentLevel, typeof(Chest), ConsoleColor.Green) as Chest;
                                chest?.TakesItems(hero);
                                IObject door = hero.CheckCollisionAround(currentLevel, typeof(Door), ConsoleColor.Green) as Door;
                                if (door != null)
                                {
                                    currentLevel.Field[door.Y, door.X] = new Floor(door.Y, door.X);
                                }

                                break;
                            case 3:
                                hero.Inventory.ManageInventory(hero, field: currentLevel);
                                break;
                        }

                        break;
                }
            }
        }
    }
}
