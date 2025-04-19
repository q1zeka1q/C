using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_alused._3._osa_C__Kordused__massiivid_ja_klassid._Teoria_Ülesanded;

namespace C_alused._3._osa_C__Kordused__massiivid_ja_klassid._Teoria_Ülesanded
{
    internal class MainClass2
    {
        public void Käivita()
        {
            FunktsioonideClass3 f = new FunktsioonideClass3();

            // 1. Ruudud
            Console.WriteLine("1. Juhuslike arvude ruudud:");
            List<int> ruudud = f.GenereeriRuudud(-100, 100);
            foreach (int ruut in ruudud)
            {
                int algarv = (int)Math.Sqrt(ruut);
                Console.WriteLine(algarv + " → " + ruut);
            }

            // 2. Viie arvu analüüs
            Console.WriteLine("\n2. Viie arvu analüüs:");
            double[] arvud = new double[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Sisesta arv " + (i + 1) + ": ");
                while (!double.TryParse(Console.ReadLine(), out arvud[i]))
                {
                    Console.Write("Vale sisend! Palun sisesta arv: ");
                }
            }
            List<Inimene> inimesed = new List<Inimene>();
            for (int i = 0; i < 5; i++)
            {
                string nimi = "";
                while (string.IsNullOrWhiteSpace(nimi))
                {
                    Console.Write("Nimi: ");
                    nimi = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nimi))
                    {
                        Console.WriteLine("Palun sisesta korrektne nimi!");
                    }
                }

                Console.Write("Vanus: ");
                int vanus;
                while (!int.TryParse(Console.ReadLine(), out vanus))
                {
                    Console.Write("Vale sisend! Palun sisesta arvuline vanus: ");
                }

                inimesed.Add(new Inimene { Nimi = nimi, Vanus = vanus });
            }
            if (inimesed.Count == 0)
            {
                Console.WriteLine("Viga: nimekiri on tühi!");
                return;
            }
            var stat = f.Statistika(inimesed);
            Console.WriteLine("Summa: " + stat.Item1 + ", Keskmine: " + stat.Item2 + ", Vanim: " + stat.Item3.Nimi + ", Noorim: " + stat.Item4.Nimi);

            // 4. Osta elevant ära
            Console.WriteLine("\n4. Osta elevant ära ülesanne:");
            List<string> sisestused = f.KuniMärksõnani("elevant", "Osta elevant ära!");
            Console.WriteLine("Sisestatud fraasid:");
            foreach (var s in sisestused)
            {
                Console.WriteLine(s);
            }

            // 5. Arvamise mäng
            Console.WriteLine("\n5. Arvamise mäng:");
            string uuesti;
            do
            {
                f.ArvaArv();
                Console.Write("Kas mängid uuesti? (jah/ei): ");
                uuesti = Console.ReadLine().ToLower();
            } while (uuesti == "jah");
        }
    }
}
