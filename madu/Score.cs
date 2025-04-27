using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    // Класс для подсчета очков игрока
    class Score
    {
        public int Points { get; private set; }

        public Score()
        {
            Points = 0;
            Draw();
        }

        public void AddPoint()
        {
            Points++;
            Draw();
        }
        private void Draw()
        {
            Console.SetCursorPosition(85, 2); // x=85, y=2 - справа от поля
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Очки: {Points}   ");
            Console.ResetColor();
        }



    }
}
