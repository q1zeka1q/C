using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.OOP
{
    public abstract class Loom
    {
        public string Nimi;

        public abstract void TeeHääl();
    }
    public class Koer : Loom
    {
        public override void TeeHääl()
        {
            Console.WriteLine("Auh-auh!");
        }
    }
}
