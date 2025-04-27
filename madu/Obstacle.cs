using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    class Obstacle : Figure
    {
        public Obstacle(int xStart, int yStart, int length, bool isHorizontal)
        {
            pList = new List<Point>();
            if (isHorizontal)
            {
                for (int i = 0; i < length; i++)
                {
                    pList.Add(new Point(xStart + i, yStart, '#'));
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    pList.Add(new Point(xStart, yStart + i, '#'));
                }
            }
        }
    }
}
