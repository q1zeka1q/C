using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
     class SpeedManager
    {
        private int speed;

        public SpeedManager()
        {
            speed = 150; // начальная скорость
        }

        public int GetCurrentSpeed(int scorePoints)
        {
            int calculatedSpeed = speed - (scorePoints * 5); // ускорение за очки
            if (calculatedSpeed < 50) // минимальная задержка
            {
                calculatedSpeed = 50;
            }
            return calculatedSpeed;
        }

        public void DecreaseSpeed()
        {
            if (speed < 300)
                speed += 50; // замедляем
        }

        public void IncreaseSpeed()
        {
            if (speed > 50)
                speed -= 20; // ускоряем
        }
    }
}
