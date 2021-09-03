using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magica.Interfaces;
using Magica.Objects.Environment;
using Magica.Objects.Environment.Walls;

namespace Magica.Levels
{
    /// <summary>
    /// Class that represents all levels in the game.
    /// </summary>
    abstract class Level : IField
    {
        /// <summary>
        /// Array that contains all objects on the level.
        /// </summary>
        private IObject[,] field;
     
        public IObject[,] Field
        {
            get
            {
                return field;
            }
            set
            {
                field = value;
            }
        }

        public Level(int y, int x, IObject[] objects)
        {
            field = new IObject[y, x];
            FieldInitialization(objects);
        }

        /// <summary>
        /// Initializing the empty level with Floor's objects and Walls' objects on the borders.
        /// Then setting all objects on the map.
        /// </summary>
        /// <param name="objects"></param>
        public virtual void FieldInitialization(IObject[] objects)
        {
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (i == 0 || i == Field.GetLength(0) - 1)
                        field[i, j] = new GorizontalWall(i, j);
                    else if (j == 0 || j == Field.GetLength(1) - 1)
                        field[i, j] = new VerticalWall(i, j);
                    else
                        field[i, j] = new Floor(i, j);
                }
            }
            for(int i = 0; i < objects.Length; i++)
            {
                field[objects[i].Y, objects[i].X] = objects[i];
            }
        }

        /// <summary>
        /// Display the current level.
        /// </summary>
        public virtual void DisplayField()
        {
            Console.Clear();

            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Console.ForegroundColor = Field[i, j].Color;
                    Console.Write($"{Field[i, j].Symbol} ");
                }
                Console.WriteLine();
            }
        }
    }
}
