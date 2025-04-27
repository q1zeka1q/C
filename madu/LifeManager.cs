using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    class LifeManager
    {
        public int Lives { get; private set; }

        public LifeManager(int startLives = 3)
        {
            Lives = startLives;
            Draw();
        }

        public void LoseLife()
        {
            Lives--;
            Draw();
        }

        public void AddLife()
        {
            Lives++;
            Draw();
        }

        private void Draw()
        {
            Console.SetCursorPosition(85, 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Жизни: {Lives}   ");
            Console.ResetColor();
        }
    }
}
