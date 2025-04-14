using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    // соединили 3 переменые в класс
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


        // Для вывода на экран точеку с помощью кардинат и символа
        // Скрывает, как конкретно выводит на экран символ
        public void draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
    }
}
