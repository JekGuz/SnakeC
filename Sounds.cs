using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media; // звук
using NAudio.Wave; // используем для звука
// через WMPLib не получилось :(

namespace SnakeC
{
    internal class Sounds
    {
        private string pathToMedia;
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public Sounds(string pathToResources)
        {
            pathToMedia = pathToResources;
        }

        public void PlayBackground()
        {
            try
            {
                Stop(); // остановить предыдущую музыку

                string fullPath = Path.Combine(pathToMedia, "soung.mp3");
                if (!File.Exists(fullPath))
                {
                    Console.WriteLine($"Файл не найден: {fullPath}");
                    return;
                }

                audioFile = new AudioFileReader(fullPath);
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
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
                string fullPath = Path.Combine(pathToMedia, fileName);
                if (!File.Exists(fullPath))
                {
                    Console.WriteLine($"Файл не найден: {fullPath}");
                    return;
                }

                var reader = new AudioFileReader(fullPath);
                var player = new WaveOutEvent();
                player.Init(reader);
                player.Play();

                player.PlaybackStopped += (s, e) =>
                {
                    player.Dispose();
                    reader.Dispose();
                };
            }
            catch (Exception ex)
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