using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    internal class VerticalLine : figure
        // наследуем с figure
    {
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            // Список для точек, чтобы из них сделать линию
            pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }

        }
    }
}