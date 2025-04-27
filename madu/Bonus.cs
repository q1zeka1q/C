using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    // Класс Bonus — описывает бонус, который появляется на карте
    class Bonus
    {
        public Point Point { get; set; }          // Место, где находится бонус
        public BonusType Type { get; set; }        // Тип бонуса (бомба, сердце, замедление, ускорение)
        public DateTime SpawnTime { get; set; }    // Время появления бонуса

        // Конструктор: создаёт бонус с координатами и типом
        public Bonus(Point point, BonusType type)
        {
            Point = point;
            Type = type;
            SpawnTime = DateTime.Now;
        }
    }

    // Перечисление BonusType — типы всех возможных бонусов
    enum BonusType
    {
        Bomb,       // Бомба — уменьшает змейку
        Heart,      // Сердце — даёт жизнь
        Slow,       // Замедляет скорость
        Lightning   // Ускоряет скорость
    }
}
