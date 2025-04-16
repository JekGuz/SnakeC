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
        Direction direction;
        public Snake(Point tail, int lenght, Direction _direction) {
            direction = _direction;
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

        internal void Move()
        {
            // вызываю метод first - первый элемент списка
            Point tail = pList.First();
            // змейка ползет вперед, удаляем хвост
            pList.Remove(tail);
            // голова идет -
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.draw();
        }
        public Point GetNextPoint()
        {
            // текущая позиция пока не переместилась
            Point head = pList.Last();
            // создаю новую точку
            Point nextPoint = new Point(head);
            // сдвинулась по направления 1 к direction
            nextPoint.Move(1, direction);
            return nextPoint;
        }
    }
}
