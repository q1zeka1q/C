using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    // Класс Obstacle — создаёт одно препятствие (горизонтальное или вертикальное)
    class Obstacle : Figure
    {
        // Конструктор — задаём место старта, длину и направление препятствия
        public Obstacle(int xStart, int yStart, int length, bool isHorizontal)
        {
            pList = new List<Point>(); // Создаём список точек

            if (isHorizontal)
            {
                // Если горизонтальное — рисуем по X вправо
                for (int i = 0; i < length; i++)
                {
                    pList.Add(new Point(xStart + i, yStart, '▓'));
                }
            }
            else
            {
                // Если вертикальное — рисуем вниз по Y
                for (int i = 0; i < length; i++)
                {
                    pList.Add(new Point(xStart, yStart + i, '▓'));
                }
            }
        }
    }
}
