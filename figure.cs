using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    // Для наследования (класс обьединяет)
    // Общий код для классов горизонт, вертикальная (они наследуют)
    // Базовый класс для своих наследников
    internal class figure
    {
        protected List<Point> pList;
        public void drow()
        {
            // цикл
            foreach (Point p in pList)
            {
                p.draw();
            }
        }
    }
}
