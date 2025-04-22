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
            Console.CursorVisible = false;    // убираю курсор
            Console.SetWindowSize(80, 25);  // Сначала выставляем размер окна - без этого не работает SetBufferSize
            Console.SetBufferSize(80, 25);  // Затем размер буфера


            // Столкновения змейки / и отрисовка рамочки
            Walls walls = new Walls(80, 25);
            walls.Draw();

            // Отрисовка точек
            Point p = new Point(4, 5, '*'); // вызвали конструктор. Инкапсуляция - это свойство системы обьяниняющие данные и методы

            // змейка
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            Console.ForegroundColor = ConsoleColor.White;
            snake.drow();

            // класс соотвествует генирации точек, чтобы появлялась еда для змейки
            FoodCreator foodCreator = new FoodCreator(80, 25, '@'); // габарит экрана и символ еды
            Point food = foodCreator.CreateFood();
            food.draw();

            // еще один цикл для еды
            while (true) 
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                    {
                    break;
                    }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);

                if (Console.KeyAvailable) // была ли нажата клавиша с прошлого цикла
                {
                    ConsoleKeyInfo key = Console.ReadKey();  // получаем значения клавиши и чему равна
                    snake.HandleKey(key.Key);
                }

            }

        }

    }
}
