using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    // Класс LifeManager — отвечает за количество жизней игрока
    class LifeManager
    {
        public int Lives { get; private set; } // Количество жизней

        // Конструктор — задаём начальное количество жизней (по умолчанию 3)
        public LifeManager(int startLives = 3)
        {
            Lives = startLives;
            Draw(); // Показать количество жизней на экране
        }

        // Метод LoseLife — уменьшаем количество жизней на 1
        public void LoseLife()
        {
            Lives--;
            Draw(); // Перерисовать после потери жизни
        }

        // Метод AddLife — увеличиваем количество жизней на 1
        public void AddLife()
        {
            Lives++;
            Draw(); // Перерисовать после добавления жизни
        }

        // Метод Draw — показывает текущие жизни в правом верхнем углу
        private void Draw()
        {
            Console.SetCursorPosition(85, 4); // Позиция для вывода жизней
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Жизни: {Lives}   ");
            Console.ResetColor();
        }
    }
}
