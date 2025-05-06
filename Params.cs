using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    internal class Params
    {
        private string resourcesFolder;

        public Params()
        {
            // получаем текущую рабочую папку (обычно это bin\Debug\net8.0)
            string currentDir = Directory.GetCurrentDirectory();
            // находим индекс слова "bin" в пути
            int binIndex = currentDir.IndexOf("bin", StringComparison.Ordinal);

            // отрезаем путь до bin — получаем путь к корню проекта
            string projectRoot = currentDir.Substring(0, binIndex);

            // склеиваем путь с папкой "resources"
            resourcesFolder = Path.Combine(projectRoot, "resources");
        }

        public string GetResourceFolder()
        {
            return resourcesFolder;
        }
    }
}
