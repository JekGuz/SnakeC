using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeC
{
    internal class Result
    {
        public static void Save(int score)
        {
            Console.Clear(); // очищаем экран перед логотипом
            ShowGameOverLogo(); // показываем ASCII-лого

            Console.SetCursorPosition(0, 22); // сообщение об окончании игры
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Score: {score}    ");
            Console.WriteLine("Game Over");

            try
            {
                Params param = new Params();
                string path = Path.Combine(param.GetResourceFolder(), "Score.txt");  // путь к Score.txt в папке resources

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    Console.SetCursorPosition(0, 23);
                    Console.Write("Sisesta nimi: ");
                    Console.SetCursorPosition(25, 23);
                    string name = Console.ReadLine();
                    sw.WriteLine($"{DateTime.Now} | {name} | Score: {score}");
                }

                // Показываем топ-3 игроков после записи результата
                ShowTop3(path);

                // Вопрос: начать ли игру заново
                Console.WriteLine("\nDo you want to play again? (Y/N)");
                ConsoleKeyInfo key = Console.ReadKey(true); // ждём ответ пользователя
                if (key.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    Program.Main(Array.Empty<string>()); // вызываем Main снова
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    Thread.Sleep(1500);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga"); // если проблема с файлом
            }
        }

        // отдельный метод показа ASCII надписи GAME OVER
        private static void ShowGameOverLogo()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            string[] logo = new string[]
            {
                @" ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  ",
                @" ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒",
                @"▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒",
                @"░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  ",
                @"░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒",
                @" ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░",
                @"  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░",
                @"░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ ",
                @"      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     ",
                @"                                                     ░                  "
            };

            int centerX = Math.Max(0, (Console.WindowWidth - logo[0].Length) / 2);
            int startY = 5;

            foreach (string line in logo)
            {
                Console.SetCursorPosition(centerX, startY++);
                Console.WriteLine(line);
            }

            Console.ResetColor(); // ресет цвета
        }

        // показывает всю историю без сортировки
        public static void ShowAll()
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // делаем текст голубым
            Console.WriteLine("Previous Results:\n");

            Params param = new Params(); // объект для получения пути
            string path = Path.Combine(param.GetResourceFolder(), "Score.txt"); // путь к Score.txt

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path); // читаем построчно

                foreach (string line in lines)
                {
                    Console.WriteLine(line); // выводим построчно
                }
            }
            else
            {
                Console.WriteLine("No results found yet.");  // если файл не найден
            }

            Console.ResetColor(); // возвращаем стандартный цвет
        }

        // метод для вывода топ-3 игроков
        private static void ShowTop3(string path)
        {
            try
            {
                List<string> lines = File.ReadAllLines(path).ToList();
                List<PlayerResult> playerResults = new List<PlayerResult>();

                foreach (string line in lines)
                {
                    try
                    {
                        string[] parts = line.Split('|'); // разбиваем строку
                        string name = parts[1].Trim(); // берём имя
                        string scoreStr = parts[2].Trim().Replace("Score: ", ""); // убираем "Score: "
                        int score = int.Parse(scoreStr); // парсим

                        playerResults.Add(new PlayerResult { Name = name, Score = score });
                    }
                    catch
                    {
                        // если строка повреждена — пропускаем
                    }
                }

                playerResults = playerResults
                    .OrderByDescending(p => p.Score) // сортировка
                    .Take(3) // только 3
                    .ToList();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTop 3 Players:");
                foreach (var p in playerResults)
                {
                    Console.WriteLine($"{p.Name} - {p.Score}");
                }
            }
            catch
            {
                Console.WriteLine("Ошибка при выводе топ игроков.");
            }
        }

        // Вспомогательный класс для хранения результата игрока
        internal class PlayerResult
        {
            public string Name { get; set; } = string.Empty;
            public int Score { get; set; }
        }
    }
}
