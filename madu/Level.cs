using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    class Level
    {
        public int CurrentLevel { get; private set; } = 1;

        public void UpdateLevel(int scorePoints)
        {
            int newLevel = (scorePoints / 5) + 1;
            if (newLevel > CurrentLevel)
            {
                CurrentLevel = newLevel;
                ShowLevelUp();
            }
        }

        private void ShowLevelUp()
        {
            int x = 30;
            int y = 12;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"=== Новый уровень: {CurrentLevel} ===");
            Console.ResetColor();
            Thread.Sleep(1000);

            // Стереть надпись
            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', 30)); // затираем пробелами строку длиной 30 символов
        }


    }
}
