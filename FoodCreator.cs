using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC
{
    internal class FoodCreator
        { // храник переменые
            int mapWidht;
            int mapHidht;
            char sym;

            Random random = new Random();

            public FoodCreator(int mapWidht, int mapHidht, char sym) // габариты карты и символ еды
            {
                this.mapWidht = mapWidht; // this - имеем ввиду та переменая, что храниться выше, без нее тогда которую пользователь вписал
                this.mapHidht = mapHidht;
                this.sym = sym;
            }
            
        public Point CreateFood()
        {
            int x = random.Next(2, mapWidht - 2);
            int y = random.Next(2, mapHidht - 2);
            return new Point(x,y,sym);
        }
    }
}
