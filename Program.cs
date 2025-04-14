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
            Point p1 = new Point(1, 2, '*'); // вызвали конструктор. Инкапсуляция - это свойство системы обьяниняющие данные и методы
            p1.draw();

            Point p2 = new Point(4, 5, '#');
            p2.draw();

            Console.ReadLine();
        }

        }
}
