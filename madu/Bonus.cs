using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    class Bonus
    {
        public Point Point { get; set; }
        public BonusType Type { get; set; }
        public DateTime SpawnTime { get; set; }

        public Bonus(Point point, BonusType type)
        {
            Point = point;
            Type = type;
            SpawnTime = DateTime.Now;
        }
    }

    enum BonusType
    {
        Bomb,
        Heart,
        Slow,
        Lightning
    }
}
