using System;
using Magica.Interfaces;
using Magica.Objects.Environment;
using Magica.Objects.Environment.Walls;

namespace Magica.Levels
{
    /// <summary>
    /// Abstract class that represents all levels in the game.
    /// </summary>
    internal abstract class Level : IField
    {
        private IObject[,] field;

        /// <summary>
        /// Initializes a new instance of the <see cref="Level"/> class.
        /// </summary>
        /// <param name="y">A vertical size of the level.</param>
        /// <param name="x">A gorizontal size of the level.</param>
        /// <param name="objects">All objects on the level.</param>
        public Level(int y, int x, IObject[] objects)
        {
            this.field = new IObject[y, x];
            this.FieldInitialization(objects);
        }

        /// <summary>
        /// Gets or sets an array that contains all the objects on the level.
        /// </summary>
        public IObject[,] Field
        {
            get
            {
                return this.field;
            }

            set
            {
                this.field = value;
            }
        }

        /// <summary>
        /// Initializes the empty level with Floor's and Walls' objects on the borders.
        /// Then sets all the objects on the level.
        /// </summary>
        /// <param name="objects">All objects on the level.</param>
        public virtual void FieldInitialization(IObject[] objects)
        {
            for (int i = 0; i < this.field.GetLength(0); i++)
            {
                for (int j = 0; j < this.field.GetLength(1); j++)
                {
                    if (i == 0 || i == this.field.GetLength(0) - 1)
                    {
                        this.field[i, j] = new GorizontalWall(i, j);
                    }
                    else if (j == 0 || j == this.field.GetLength(1) - 1)
                    {
                        this.field[i, j] = new VerticalWall(i, j);
                    }
                    else
                    {
                        this.field[i, j] = new Floor(i, j);
                    }
                }
            }

            for (int i = 0; i < objects.Length; i++)
            {
                this.field[objects[i].Y, objects[i].X] = objects[i];
            }
        }

        /// <summary>
        /// Displays the current level.
        /// </summary>
        public virtual void DisplayField()
        {
            Console.Clear();

            for (int i = 0; i < this.field.GetLength(0); i++)
            {
                for (int j = 0; j < this.field.GetLength(1); j++)
                {
                    Console.ForegroundColor = this.field[i, j].Color;
                    Console.Write($"{this.field[i, j].Symbol} ");
                }

                Console.WriteLine();
            }
        }
    }
}
