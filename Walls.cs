using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    internal class Walls
    {
        List<figure> wallList;

        public Walls(int mapWidth, int mapHeight) 
        {
            wallList = new List<figure>();

            // Рамочка отрисовка
            //5 - left 10 right, 8 rida, sym +
            HorizontalLine upline = new HorizontalLine(0, mapWidth - 1, 0, '-');
            HorizontalLine downline = new HorizontalLine(0, mapWidth - 1, mapHeight - 1, '-');
            VerticalLine leftline = new VerticalLine(0, mapHeight - 1, 0, '|');
            VerticalLine rightline = new VerticalLine(0, mapHeight - 1, mapWidth - 1, '|');
            Console.ForegroundColor = ConsoleColor.Red; // цвета для группы линий
            // добавляем в список
            wallList.Add(upline);
            wallList.Add(downline);
            wallList.Add(leftline);
            wallList.Add(rightline);
        }
        
        internal bool IsHit(figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.drow();
            }
        }
    }
}
