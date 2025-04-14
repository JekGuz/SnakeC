using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);  // Сначала выставляем размер окна - без этого не работает SetBufferSize
            Console.SetBufferSize(80, 25);  // Затем размер буфера


            // Рамочка отрисовка
            //5 - left 10 right, 8 rida, sym +
            HorizontalLine upline = new HorizontalLine(0, 78, 0, '-');
            HorizontalLine downline = new HorizontalLine(0, 78, 24, '-');
            VerticalLine leftline = new VerticalLine(0, 24, 0, '|');
            VerticalLine rightline = new VerticalLine(0, 24, 78, '|');
            upline.drow();
            downline.drow();
            leftline.drow();
            rightline.drow();

            // Отрисовка точек
            Point p = new Point(4, 5, '*'); // вызвали конструктор. Инкапсуляция - это свойство системы обьяниняющие данные и методы

            // змейка
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.drow();
           
            Console.ReadLine();
        }

    }
}
