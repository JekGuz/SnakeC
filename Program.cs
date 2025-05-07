using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    class Program
    {
        public static void Main(string[] args)   // нужен он public чтобы его видил result т.к. хочу выводить игроков
        {
            int score = 0; // добавляем счетчик на сколько сьедим
            Console.CursorVisible = false;    // убираю курсор
            // увеличиваем окно, т.к. проблемы с старовым экраном из за большой надписи
            Console.SetWindowSize(100, 30);  // Сначала выставляем размер окна - без этого не работает SetBufferSize   
            Console.SetBufferSize(100, 30);  // Затем размер буфера

            // звук фона
            Params param = new Params(); // путь к папке resources
            Sounds sound = new Sounds(param.GetResourceFolder()); // передаём путь
            sound.PlayBackground(); // запускаем фоновую музыку

            // стартовый экран 
            if (!StartScreen.Show())   // если в startscreen выбирут 3 тогда вернется false и програма завершиться
            {
                return; // пользователь выбрал Exit → игра не запускается
            }

            Level level = new Level(); // начнем добавлять уровень ( начнем читать наш уровень)

            // Столкновения змейки / и отрисовка рамочки
            Walls walls = new Walls(80, 25);
            walls.Draw();

            // Отрисовка точек
            Point p = new Point(4, 5, '*'); // вызвали конструктор. Инкапсуляция - это свойство системы обьяниняющие данные и методы

            // змейка
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            Console.ForegroundColor = level.SnakeColor; // заменяем, просто белую, т.к. теперь уровни будут придавать цвет, потом римуем
            snake.drow();

            // отображения счета во время игры
            static void ShowScore(int score)
            {
                Console.SetCursorPosition(0, 0); //верхний левый угол
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Score: {score}   "); // добавим пробелы, чтобы затирать старые значения
            }

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
                    score++;
                    ShowScore(score);
                    level.UpdateLevel(score);
                    

                    Console.ForegroundColor = level.FoodColor;
                    food = foodCreator.CreateFood();
                    food.draw(); // <-- только здесь
                }
                else
                {
                    Console.ForegroundColor = level.SnakeColor;
                    snake.Move();
                }
                Thread.Sleep(level.Speed); // чем меньше число, тем быстрее движется змейка.

                if (Console.KeyAvailable) // была ли нажата клавиша с прошлого цикла
                {
                    ConsoleKeyInfo key = Console.ReadKey();  // получаем значения клавиши и чему равна
                    snake.HandleKey(key.Key);
                }

            }
            sound.Stop();           // остановить фоновую музыку
            sound.PlayGameOver();   // проиграть звук окончания
            Result.Save(score);     // сохранить результат
        }

    }
}
