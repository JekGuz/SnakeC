using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    // соединили 3 переменые в класс
    // данные
    class Point
    {
        public int x;
        public int y;
        public char sym;

        // Конструктор
        public Point()
        {            
        }

        // хочу заполнить переменых относящихся к данной точке
        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        // новый конструктор, задаем точки с помощью другой точки
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        // метод move который будет сдигать данную точку на растояни offset к direction
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if (direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset;
            }
            else if (direction == Direction.DOWN)
            {
                y = y + offset;
            }
        }         

                // Для вывода на экран точеку с помощью кардинат и символа
                // Скрывает, как конкретно выводит на экран символ
                // метод для вызова
        public void draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
         }

        // Удаляем хвостовой последний символ, чтобы сделать перемещение
        public void Clear()
        {
            sym = ' ';
            draw();
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
    }
}
