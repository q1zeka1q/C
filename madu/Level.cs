using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    // Класс Level — отвечает за уровни игры (чем больше очков, тем выше уровень)
    class Level
    {
        public int CurrentLevel { get; private set; } = 1; // Текущий уровень, изначально 1

        // Метод UpdateLevel — проверяет, нужно ли повысить уровень в зависимости от очков
        public void UpdateLevel(int scorePoints)
        {
            int newLevel = (scorePoints / 5) + 1; // Каждые 5 очков новый уровень
            if (newLevel > CurrentLevel)
            {
                CurrentLevel = newLevel;
                ShowLevelUp(); // Показать сообщение о новом уровне
            }
        }

        // Метод ShowLevelUp — показывает сообщение о переходе на новый уровень
        private void ShowLevelUp()
        {
            int x = 30;
            int y = 12;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"=== Новый уровень: {CurrentLevel} ===");
            Console.ResetColor();
            Thread.Sleep(1000); // Подождать 1 секунду

            // Стереть надпись после показа
            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', 30)); // Затираем строку 30 пробелами
        }
    }
}
