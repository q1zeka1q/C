using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    // Класс Walls отвечает за создание и отрисовку стен, а также проверку столкновений с ними
    // Класс Walls отвечает за создание и отрисовку стен, а также проверку столкновений с ними
    class Walls
    {
        List<Figure> wallList;  // список фигур

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            // Создание рамки вокруг поля
            HorizontalLine upLine = new HorizontalLine(1, mapWidth - 3, 0, '═');
            HorizontalLine downLine = new HorizontalLine(1, mapWidth - 3, mapHeight - 1, '═');
            VerticalLine leftLine = new VerticalLine(1, mapHeight - 2, 0, '║');
            VerticalLine rightLine = new VerticalLine(1, mapHeight - 2, mapWidth - 2, '║');

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);

            // Углы рамки
            HorizontalLine topLeftCorner = new HorizontalLine(0, 0, 0, '╔');
            HorizontalLine topRightCorner = new HorizontalLine(mapWidth - 2, mapWidth - 2, 0, '╗');
            HorizontalLine bottomLeftCorner = new HorizontalLine(0, 0, mapHeight - 1, '╚');
            HorizontalLine bottomRightCorner = new HorizontalLine(mapWidth - 2, mapWidth - 2, mapHeight - 1, '╝');

            wallList.Add(topLeftCorner);
            wallList.Add(topRightCorner);
            wallList.Add(bottomLeftCorner);
            wallList.Add(bottomRightCorner);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }

        public void AddObstacle(int mapWidth, int mapHeight)
        {
            Random rand = new Random();
            int x = rand.Next(10, mapWidth - 10);
            int y = rand.Next(5, mapHeight - 5);
            int length = rand.Next(3, 7);
            bool isHorizontal = rand.Next(0, 2) == 0; // случайный выбор: горизонталь или вертикаль

            Obstacle obstacle = new Obstacle(x, y, length, isHorizontal); // используем Obstacle
            wallList.Add(obstacle);
            obstacle.Draw();
        }


    }
}

