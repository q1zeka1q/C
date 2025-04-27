using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    class HorizontalLine : Figure
    {
        /* Создаёт горизонтальную линию из символов от xLeft до xRight на высоте y
Каждая точка линии добавляется в список pList */
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            { 
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
        public void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
    }
}
