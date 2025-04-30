using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.OOP
{
    internal class MainClass
    {
        
        static void Main(string[] args)
        {
            //Klass создание обектав класса Inimene
            Inimene inimene1 = new Inimene();
            inimene1.Nimi = "Katrin";
            inimene1.Vanus = 30;

            inimene1.Tervita();

            //Klass создание наследование 
            Töötaja töötaja1 = new Töötaja();
            töötaja1.Nimi = "Marek";
            töötaja1.Vanus = 28;
            töötaja1.Ametikoht = "programmeerija";

            töötaja1.Tervita();
            töötaja1.Töötan();
            //Üldine loomaklass
            Koer muKoer = new Koer();
            muKoer.Nimi = "Rex";

            Console.WriteLine("Koera nimi on " + muKoer.Nimi);
            muKoer.TeeHääl();
            // Pank – klass, mis hoiab kontosummat (saldo) ja lubab ainult positiivseid väärtusi
            Pank minuPank = new Pank();
            minuPank.Saldo = 100;               // Устанавливаем saldo
            Console.WriteLine("Saldo: " + minuPank.Saldo);  // Выводим saldo
            minuPank.Saldo = -50;                  // Попытка установить отрицательное значение (не сработает)
            Console.WriteLine("Saldo: " + minuPank.Saldo);
            //определяет какие методы должны быть реалезованы
            Kass minuKass = new Kass();
            minuKass.TeeHääl();
        }
    }
}
