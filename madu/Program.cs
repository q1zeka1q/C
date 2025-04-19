﻿using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    /* Класс Program запускает игру "Змейка": создаёт стены, змейку и еду,
     обрабатывает столкновения, нажатия клавиш и выводит экран окончания игры */
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            Walls walls = new Walls(80, 25);
            walls.Draw();

            // Отрисовка точек
            Point p = new Point(4, 5, '*');  // x, y, символ
            Snake snake = new Snake(p, 4, Direction.RIGHT);  // координаты, длина и направление
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())  // проверка столкновения змейки об стену или с хвостом
                {
                    break;
                }

                if (snake.Eat(food)) // если змейка встретится с едой
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);

                if (Console.KeyAvailable)  // обработка нажатия клавиш
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            WriteGameOver();
            Console.ReadLine();
        }

        // выводит сообщение об окончании игры в консоли
static void WriteGameOver()
{
    int xOffset = 20;
    int yOffset = 8;

    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.SetCursorPosition(xOffset, yOffset++);
    WriteText("╔════════════════════════════════════╗", xOffset, yOffset++);
    WriteText("║                                    ║", xOffset, yOffset++);
    
    Console.ForegroundColor = ConsoleColor.Red;
    WriteText("║           ██████   ██████          ║", xOffset, yOffset++);
    WriteText("║         ██      █ █      ██        ║", xOffset, yOffset++);
    WriteText("║         ██  ▓▓▓▓   ▓▓▓▓  ██        ║", xOffset, yOffset++);
    WriteText("║         ██              ██        ║", xOffset, yOffset++);
    WriteText("║         ██   GAME OVER   ██        ║", xOffset, yOffset++);
    WriteText("║         ██              ██        ║", xOffset, yOffset++);
    WriteText("║         ██  ████████   ██        ║", xOffset, yOffset++);
    WriteText("║         ██      █      ██        ║", xOffset, yOffset++);
    WriteText("║           ██████ ██████          ║", xOffset, yOffset++);

    Console.ForegroundColor = ConsoleColor.DarkRed;
    WriteText("║                                    ║", xOffset, yOffset++);
    WriteText("╠════════════════════════════════════╣", xOffset, yOffset++);
    
    Console.ForegroundColor = ConsoleColor.Gray;
    WriteText($"║  Student: Evgeniy Vasiliev         ║", xOffset, yOffset++);
    WriteText($"║  Game   : Snake                    ║", xOffset, yOffset++);
    
    Console.ForegroundColor = ConsoleColor.DarkRed;
    WriteText("╚════════════════════════════════════╝", xOffset, yOffset++);

    Console.ResetColor();
}


        // выводит текст в указанной позиции
        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
