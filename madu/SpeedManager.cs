using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    // Класс SpeedManager — управляет скоростью змейки
    class SpeedManager
    {
        private int speed; // текущее значение скорости

        // Конструктор — устанавливаем начальную скорость
        public SpeedManager()
        {
            speed = 150; // начальная скорость (чем меньше число — тем быстрее)
        }

        // Метод, чтобы получить текущую скорость в зависимости от очков
        public int GetCurrentSpeed(int scorePoints)
        {
            int calculatedSpeed = speed - (scorePoints * 5); // скорость увеличивается (змейка быстрее)
            if (calculatedSpeed < 50) // устанавливаем минимальную скорость
            {
                calculatedSpeed = 50;
            }
            return calculatedSpeed;
        }

        // Метод для замедления змейки
        public void DecreaseSpeed()
        {
            if (speed < 300)
                speed += 50; // делаем змейку медленнее
        }

        // Метод для ускорения змейки
        public void IncreaseSpeed()
        {
            if (speed > 50)
                speed -= 20; // делаем змейку быстрее
        }
    }
}
