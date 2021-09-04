using System;
using Magica.Objects.Units;
using Magica.Interfaces;
using Magica.Objects.Environment;
using Magica.GameFolder;

namespace Magica.Battles
{
    /// <summary>
    /// Class that represents battle in the game between hero and monster.
    /// </summary>
    internal class Battle
    {
        /// <summary>
        /// Log of the battle under the battle panel (scroll down during the battle).
        /// Contains all actions that happen in each round.
        /// </summary>
        private static string[] log;

        private Hero hero;
        private Monster monster;

        /// <summary>
        /// Initializes a new instance of the <see cref="Battle"/> class.
        /// </summary>
        /// <param name="hero">Current hero.</param>
        /// <param name="monster">Enemy.</param>
        public Battle(Hero hero, Monster monster)
        {
            this.hero = hero;
            this.monster = monster;
            log = new string[0];
        }

        /// <summary>
        /// Adding new action to the log.
        /// </summary>
        /// <param name="action">The action that happened.</param>
        public static void ChangeLog(string action)
        {
            string[] temp = log;
            log = new string[temp.Length + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                log[i] = temp[i];
            }

            log[temp.Length] = action;
        }

        /// <summary>
        /// Method that represents whole battle process.
        /// </summary>
        /// <param name="field">Current level.</param>
        public void PlayBattle(IField field)
        {
            int action = 0;
            int round = 0;

            while (true)
            {
                this.DrawBattle(action);
                if (this.hero.CurrentHp <= 0)
                {
                    Game.GameOver();
                    log = new string[0];
                }

                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (action > 0)
                        {
                            action -= 1;
                        }

                        break;
                    case ConsoleKey.RightArrow:
                        if (action < this.hero.Skills.Length - 1)
                        {
                            action += 1;
                        }

                        break;
                    case ConsoleKey.Enter:
                        ChangeLog($"ROUND {++round}:");
                        this.hero.Skills[action].DoAction(this.hero, this.monster);
                        if (this.monster.CurrentHp > 0)
                        {
                            this.monster.Skills[0].DoAction(this.monster, this.hero);
                            this.monster.UnitState?.Invoke(this.monster);
                            this.hero.UnitState?.Invoke(this.hero);
                        }
                        else
                        {
                            this.hero.Inventory.ChangeInventory(true, this.monster.Inventory.UnitInventory);
                            field.Field[this.monster.Y, this.monster.X] = this.hero;
                            field.Field[this.hero.Y, this.hero.X] = new Floor(this.hero.Y, this.hero.X);
                            this.hero.Y = this.monster.Y;
                            this.hero.X = this.monster.X;
                            this.hero.UnitState = null;
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
            for (int i = 0; i < 27; i++)
            {
                switch (i)
                {
                    case 2:
                        Console.Write($"-- {this.monster.Name} --");
                        step = $"-- {this.monster.Name} --".Length;
                        break;
                    case 4:
                        Console.Write($"HP: {this.monster.CurrentHp}");
                        step = $"HP: {this.monster.CurrentHp}".Length;
                        break;
                    case 5:
                        Console.Write($"Mana: {this.monster.CurrentMp}");
                        step = $"Mana: {this.monster.CurrentMp}".Length;
                        break;
                    case 7:
                        Console.Write($"DMG: {this.monster.Dmg}");
                        step = $"DMG: {this.monster.Dmg}".Length;
                        break;
                    case 11:
                        Console.Write($"-- {this.hero.Name} --");
                        step = $"-- {this.hero.Name} --".Length;
                        break;
                    case 13:
                        Console.Write($"HP: {this.hero.CurrentHp}");
                        step = $"HP: {this.hero.CurrentHp}".Length;
                        break;
                    case 14:
                        Console.Write($"Mana: {this.hero.CurrentMp}");
                        step = $"Mana: {this.hero.CurrentMp}".Length;
                        break;
                    case 16:
                        Console.Write($"DMG: {this.hero.Dmg}");
                        step = $"DMG: {this.hero.Dmg}".Length;
                        break;
                }

                if (i >= 17)
                {
                    for (int j = 0; j < this.hero.Skills.Length; j++)
                    {
                        Console.Write($"{this.hero.Skills[j].Asset[i - 17]}   ");
                    }
                }

                for (int j = step; j < 20; j++)
                {
                    Console.Write(' ');
                }

                if (i < this.monster.Image.Length)
                {
                    Console.Write(this.monster.Image[i]);
                }

                step = 0;

                Console.WriteLine();
            }

            for (int i = 0; i < this.hero.Skills.Length; i++)
            {
                Console.Write(this.hero.Skills[i].Name);
                for (int j = 0; j < 13 - this.hero.Skills[i].Name.Length; j++)
                {
                    Console.Write(' ');
                }
            }

            Console.WriteLine();

            for (int i = 0; i < action * 13; i++)
            {
                Console.Write(' ');
            }

            Console.WriteLine("__________\n");

            for (int i = 0; i < log.Length; i++)
            {
                Console.WriteLine(log[i]);
            }

            Console.SetWindowPosition(0, 0);
        }
    }
}
