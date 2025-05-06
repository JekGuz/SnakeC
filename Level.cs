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
        public ConsoleColor FoodColor { get; private set; } = ConsoleColor.White;

        public void UpdateLevel(int score)
        {
            if (score >= 10)  // сильно ускоряется и желтая
            {
                level = 4;
                Speed = 40;
                SnakeColor = ConsoleColor.Yellow;
                FoodColor = ConsoleColor.Yellow;
            }
            else if (score >= 6)  // ускоряется сильнее и цвет зелеый после 6
            {
                level = 3;
                Speed = 60;
                SnakeColor = ConsoleColor.Green;
                FoodColor = ConsoleColor.Green;

            }
            else if (score >= 3) // далее сьест сколько то
            {
                level = 2;
                Speed = 80;
                SnakeColor = ConsoleColor.Cyan;
                FoodColor = ConsoleColor.Blue;
            }
            else
            {
                level = 1;  // начало
                Speed = 100;
                SnakeColor = ConsoleColor.White;
                FoodColor = ConsoleColor.White;
            }
        }
    }
}

