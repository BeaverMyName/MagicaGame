using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Objects.Units;
using Magica.Interfaces;
using Magica.Objects.Environment;
using Magica.Objects;
using Magica.GameFolder;
using Magica.UnitInventory;
using Magica.GameAssets;

namespace Magica.Battles
{
    /// <summary>
    /// Class that represents battle in the game between hero and monster.
    /// </summary>
    class Battle
    {
        private Hero hero;
        private Monster monster;
        /// <summary>
        /// Log of the battle under the battle panel (scroll down during the battle).
        /// Contains all actions that happen in each round.
        /// </summary>
        private static string[] log;

        public Battle(Hero hero, Monster monster)
        {
            this.hero = hero;
            this.monster = monster;
            log = new string[0];
        }

        /// <summary>
        /// Adding new action to the log.
        /// </summary>
        /// <param name="action">The action that happened</param>
        public static void ChangeLog(string action)
        {
            string[] temp = log;
            log = new string[temp.Length + 1];
            for (int i = 0; i < temp.Length; i++)
                log[i] = temp[i];
            log[temp.Length] = action;
        }

        /// <summary>
        /// Method that represents whole battle process. 
        /// </summary>
        /// <param name="field">Current level</param>
        public void PlayBattle(IField field)
        {
            int action = 0;
            int round = 0;

            while (true)
            {
                DrawBattle(action);
                if (hero.CurrentHp <= 0)
                {
                    Game.GameOver();
                    log = new string[0];
                }
                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (action > 0)
                            action -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (action < hero.Skills.Length - 1)
                            action += 1;
                        break;
                    case ConsoleKey.Enter:
                        ChangeLog($"ROUND {++round}:");
                        
                        hero.Skills[action].Action(hero, monster);
                        if (monster.CurrentHp > 0)
                        {
                            monster.Skills[0].Action(monster, hero);
                            monster.UnitState?.Invoke(monster);
                            hero.UnitState?.Invoke(hero);
                        }
                        else
                        {
                            hero.Inventory.ChangeInventory(true, monster.Inventory.UnitInventory);
                            field.Field[monster.Y, monster.X] = hero;
                            field.Field[hero.Y, hero.X] = new Floor(hero.Y, hero.X);
                            hero.Y = monster.Y;
                            hero.X = monster.X;
                            hero.UnitState = null;
                            log = new string[0];
                            return;
                        }
                        
                        break;
                }
                
            }
        }

        private void DrawBattle(int action)
        {
            int step = 0;
            Console.Clear();
            for(int i = 0; i < 27; i++)
            {
                switch (i)
                {
                    case 2:
                        Console.Write($"-- {monster.Name} --");
                        step = $"-- {monster.Name} --".Length;
                        break;
                    case 4:
                        Console.Write($"HP: {monster.CurrentHp}");
                        step = $"HP: {monster.CurrentHp}".Length;
                        break;
                    case 5:
                        Console.Write($"Mana: {monster.CurrentMp}");
                        step = $"Mana: {monster.CurrentMp}".Length;
                        break;
                    case 7:
                        Console.Write($"DMG: {monster.Dmg}");
                        step = $"DMG: {monster.Dmg}".Length;
                        break;
                    case 11:
                        Console.Write($"-- {hero.Name} --");
                        step = $"-- {hero.Name} --".Length;
                        break;
                    case 13:
                        Console.Write($"HP: {hero.CurrentHp}");
                        step = $"HP: {hero.CurrentHp}".Length;
                        break;
                    case 14:
                        Console.Write($"Mana: {hero.CurrentMp}");
                        step = $"Mana: {hero.CurrentMp}".Length;
                        break;
                    case 16:
                        Console.Write($"DMG: {hero.Dmg}");
                        step = $"DMG: {hero.Dmg}".Length;
                        break;
                }

                if (i >= 17)
                {
                    for (int j = 0; j < hero.Skills.Length; j++)
                    {
                        Console.Write($"{hero.Skills[j].Asset[i - 17]}   ");
                    }
                }

                for (int j = step; j < 20; j++)
                {
                    Console.Write(' ');
                }

                if (i < monster.Image.Length)
                    Console.Write(monster.Image[i]);
                step = 0;

                Console.WriteLine();
            }

            for (int i = 0; i < hero.Skills.Length; i++)
            {
                Console.Write(hero.Skills[i].Name);
                for (int j = 0; j < 13 - hero.Skills[i].Name.Length; j++)
                    Console.Write(' ');
            }

            Console.WriteLine();

            for(int i = 0; i < action * 13; i++)
            {
                Console.Write(' ');
            }
            Console.WriteLine("__________\n");

            for(int i = 0; i < log.Length; i++)
            {
                Console.WriteLine(log[i]);
            }

            Console.SetWindowPosition(0, 0);
        }
    }
}
