using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media; // // встроенная поддержка .wav-звуков (ограничено)
using NAudio.Wave; // библиотека NAudio — поддерживает .mp3, управление, события
// через WMPLib не получилось :(
//WMPLib (Windows Media Player) — внешняя COM-библиотека, сложнее в настройке, меньше контроля.
// NAudio.Wave — .NET - библиотека, легко использовать, поддерживает .mp3, можно зациклить, управлять громкостью, остановкой, продолжением.

namespace SnakeC
{
    internal class Sounds
    {
        private string pathToMedia;    // путь к папке resources со звуками
        private WaveOutEvent outputDevice;   // объект для вывода звука
        private AudioFileReader audioFile;   // mp3-файл, который читается

        public Sounds(string pathToResources)
        {
            pathToMedia = pathToResources;    // сохраняем путь к папке со звуками
        }

        public void PlayBackground()
        {
            try
            {
                Stop(); // остановить предыдущую музыку

                string fullPath = Path.Combine(pathToMedia, "soung.mp3");
                if (!File.Exists(fullPath))  // проверка, существует ли файл
                {
                    Console.WriteLine($"Файл не найден: {fullPath}");
                    return;
                }
                 
                audioFile = new AudioFileReader(fullPath);   // создаём поток чтения mp3
                outputDevice = new WaveOutEvent();     // создаём устройство для воспроизведения
                outputDevice.Init(audioFile);   // подключаем поток к устройству
                outputDevice.Play();   // начинаем воспроизведение
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка воспроизведения фоновой музыки: " + ex.Message);
            }
        }

        public void PlayEat()
        {
            PlayOnce("eat.mp3");
        }

        public void PlayGameOver()
        {
            PlayOnce("crash.mp3");
        }

        private void PlayOnce(string fileName)
        {
            try
            {
                string fullPath = Path.Combine(pathToMedia, fileName);   // формируем путь
                if (!File.Exists(fullPath))   // нет файла ошибка
                {
                    Console.WriteLine($"Файл не найден: {fullPath}");
                    return;
                }

                AudioFileReader reader = new AudioFileReader(fullPath);   // Создаём объект, который умеет читать .mp3
                WaveOutEvent player = new WaveOutEvent();                 // Создаём объект, который воспроизводит звук
                player.Init(reader);                                      // Подключаем" звук к плееру
                player.Play();                                            // Запускаем проигрывание


                // Это часть класса WaveOutEvent (библиотека NAudio).
                player.PlaybackStopped += (sender, args) =>               // событие завершения // Это значит: "подпишись" на событие PlaybackStopped.
                {
                    player.Dispose();   // Освобождаем проигрыватель
                    reader.Dispose();   // Освобождаем файл
                };
            }
            catch (Exception ex)   // Если что-то пошло не так (например, повреждён файл), покажем ошибк
            {
                Console.WriteLine($"Ошибка воспроизведения звука '{fileName}': " + ex.Message);
            }
        }

        public void Stop()
        {
            outputDevice?.Stop();
            outputDevice?.Dispose();
            audioFile?.Dispose();

            outputDevice = null;
            audioFile = null;
        }
    }
}