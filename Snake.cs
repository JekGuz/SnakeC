using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    // наследует с фируге класс
    internal class Snake : figure
    {
        public Snake(Point tail, int lenght, Direction direction) {
            // List
            pList = new List<Point>();

            // цикл
            for (int i = 0; i < lenght; i++)
            {
                // несколько раз создаем хвост
                Point p = new Point(tail);
                // сдвигаем к директон
                p.Move(i, direction);
                // хвостовая точка попадет в список
                pList.Add(p);
            }
        }
    }
}
