using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.OOP
{
    //Klass создание обектав класса Inimene
    public class Inimene
    {
        public string Nimi;
        public int Vanus;

        public void Tervita()
        {
            Console.WriteLine("Tere! Mina olen " + Nimi);
        }
    }
}
