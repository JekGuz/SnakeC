using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    internal static class StartScreen
    {
        public static bool Show()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            // логотип можно сделать тут https://patorjk.com/software/taag/#p=display&f=Bloody&t=Snake%20Game
            string[] logo = new string[]
            {
                @" ██████  ███▄    █  ▄▄▄       ██ ▄█▀▓█████      ▄████  ▄▄▄       ███▄ ▄███▓▓█████",
                @"▒██    ▒  ██ ▀█   █ ▒████▄     ██▄█▒ ▓█   ▀     ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀",
                @"░ ▓██▄   ▓██  ▀█ ██▒▒██  ▀█▄  ▓███▄░ ▒███      ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███ ",
                @"  ▒   ██▒▓██▒  ▐▌██▒░██▄▄▄▄██ ▓██ █▄ ▒▓█  ▄    ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄ ",
                @"▒██████▒▒▒██░   ▓██░ ▓█   ▓██▒▒██▒ █▄░▒████▒   ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒",
                @"▒ ▒▓▒ ▒ ░░ ▒░   ▒ ▒  ▒▒   ▓▒█░▒ ▒▒ ▓▒░░ ▒░ ░    ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░",
                @"░ ░▒  ░ ░░ ░░   ░ ▒░  ▒   ▒▒ ░░ ░▒ ▒░ ░ ░  ░     ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░",
                @"░  ░  ░     ░   ░ ░   ░   ▒   ░ ░░ ░    ░      ░ ░   ░   ░   ▒   ░      ░      ░   ",
                @"      ░           ░       ░  ░░  ░      ░  ░         ░       ░  ░       ░      ░  ░",
                @"                                                                                   "
            };

            int centerX = Math.Max(0, (Console.BufferWidth - logo[0].Length) / 2);
            int startY = 5;

            // Рисуем лого
            for (int i = 0; i < logo.Length; i++)
            {
                Console.SetCursorPosition(centerX, startY + i);
                Console.WriteLine(logo[i]);
            }

            // выводим меню
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(centerX + 12, startY + logo.Length + 2);
            Console.WriteLine("1 - Start Game");

            Console.SetCursorPosition(centerX + 12, startY + logo.Length + 3);
            Console.WriteLine("2 - Exit");

            Console.ResetColor();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                {
                    // объединяем логотип и меню для стирания
                    string[] fullScreen = logo.Concat(new string[]
                    {
                        "",
                        "",
                        "1 - Start Game",
                        "2 - Exit"
                    }).ToArray();

                    // стираем всё с экрана
                    FadeOutCharByChar(fullScreen, centerX, startY);
                    Console.Clear();  // очищаем после анимации
                    return true;
                }
                else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.Escape)
                {
                    return false;
                }
            }
        }

        // метод для анимации затухания по символам
        private static void FadeOutCharByChar(string[] logo, int startX, int startY)
        {
            for (int y = 0; y < logo.Length; y++)
            {
                for (int x = 0; x < logo[y].Length; x++)
                {
                    int posX = startX + x;
                    int posY = startY + y;

                    // Проверка на границы буфера
                    if (posX >= 0 && posX < Console.BufferWidth && posY >= 0 && posY < Console.BufferHeight)
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.Write(' ');
                    }
                }
                Thread.Sleep(10); // задержка между строками (визуальный эффект)
            }

            Console.ResetColor();
        }
    }
}
