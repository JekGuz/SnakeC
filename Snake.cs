using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeC
{
    // наследует с фируге класс
    internal class Snake : figure
    {
        public Direction direction; // ключевое слова, public чтобы читать из вне
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

        // не укусила ли змейка свой хвост
        internal bool IsHitTail()
        {
            var head = pList.Last();  // т.к. голова это последняя точка ( сделала себе большую ошибку
            for (int i = 0; i < pList.Count -2; i++)
            {
                if(head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        public void HandleKey(ConsoleKey key) 
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if(head.IsHit(food))
            {
                food.sym = head.sym; // точка будет равна симфолу звезочка чтобы удленить змейку
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
    }
}
