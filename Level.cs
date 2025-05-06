using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    internal class Level
    {
        public int level { get; private set; } = 1;
        public int Speed { get; private set; } = 100;
        public ConsoleColor SnakeColor { get; private set; } = ConsoleColor.White;
        public ConsoleColor FoodColor { get; private set; } = ConsoleColor.Red;

        public void UpdateLevel(int score)
        {
            if (score >= 10)
            {
                level = 4;
                Speed = 40;
                SnakeColor = ConsoleColor.Yellow;
                FoodColor = ConsoleColor.Yellow;
            }
            else if (score >= 6)
            {
                level = 3;
                Speed = 60;
                SnakeColor = ConsoleColor.Green;
                FoodColor = ConsoleColor.White;

            }
            else if (score >= 3)
            {
                level = 2;
                Speed = 80;
                SnakeColor = ConsoleColor.Cyan;
                FoodColor = ConsoleColor.Blue;
            }
            else
            {
                level = 1;
                Speed = 100;
                SnakeColor = ConsoleColor.White;
                FoodColor = ConsoleColor.Red;
            }
        }
    }
}

