using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                Params p = new Params();
                string path = Path.Combine(p.GetResourceFolder(), "Score.txt");  // (AppDomain.CurrentDomain.BaseDirectory, "Score.txt") - теперь у нас путь к папке resources
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    Console.SetCursorPosition(0, 23);
                    Console.Write("Sisesta nimi: ");
                    Console.SetCursorPosition(25, 23);
                    string name = Console.ReadLine();
                    sw.WriteLine($"{DateTime.Now} | {name} | Score: {score}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga");
            }
        }

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

            Console.ResetColor();
        }
        public static void ShowAll()     // показывает игроку всю историю его игр
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // будем красиво выделять например голубым
            Console.WriteLine("Previous Results:\n");

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Score.txt"); // путь к файлу
            if (File.Exists(path))  // проверяем есть ли этот фаил
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    Console.WriteLine(line); // считываем все сточки
                }
            }
            else
            {
                Console.WriteLine("No results found yet.");  // это плохо файл поврежден или его нет
            }

            Console.ResetColor(); // ресет колор
        }

    }
}