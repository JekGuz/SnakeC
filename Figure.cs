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
        public virtual void drow()  // виртуальный теперь, может переопределить и сделать свою дров
        {
            // цикл
            foreach (Point p in pList)
            {
                p.draw();
            }
        }

        internal bool IsHit(figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }
        private bool IsHit(Point point) 
        { 
            foreach(var p in pList)
            {
                if ( p.IsHit(point)) 
                    return true;
            }
            return false;
        }
    }
}
