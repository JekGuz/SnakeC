using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    internal class HorizontalLine : figure
        // горизонтальный класс наследуется от figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            // Список для точек, чтобы из них сделать линию
            pList = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }

        }

    }
}
