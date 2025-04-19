using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused._3._osa_C__Kordused__massiivid_ja_klassid._Teoria_Ülesanded
{
    internal class FunktsioonideClass3
    {
        public List<int> GenereeriRuudud(int min, int max)
        {
            Random rnd = new Random();
            int n = rnd.Next(min, max + 1);
            int m = rnd.Next(min, max + 1);

            int algus = Math.Min(n, m);
            int lopp = Math.Max(n, m);

            List<int> ruudud = new List<int>();
            for (int i = algus; i <= lopp; i++)
            {
                ruudud.Add(i * i);
            }

            return ruudud;
        }

        public Tuple<double, double, double> AnalüüsiArve(double[] arvud)
        {
            double summa = 0;
            double korrutis = 1;
            foreach (double arv in arvud)
            {
                summa += arv;
                korrutis *= arv;
            }
            double keskmine = summa / arvud.Length;
            return Tuple.Create(summa, keskmine, korrutis);
        }

        public Tuple<int, double, Inimene, Inimene> Statistika(List<Inimene> inimesed)
        {
            int summa = 0;
            Inimene vanim = inimesed[0];
            Inimene noorim = inimesed[0];

            foreach (var inimene in inimesed)
            {
                summa += inimene.Vanus;
                if (inimene.Vanus > vanim.Vanus) vanim = inimene;
                if (inimene.Vanus < noorim.Vanus) noorim = inimene;
            }
            double keskmine = (double)summa / inimesed.Count;
            return Tuple.Create(summa, keskmine, vanim, noorim);
        }

        public List<string> KuniMärksõnani(string märksõna, string fraas)
        {
            List<string> sisestused = new List<string>();
            string sisend;
            do
            {
                Console.WriteLine(fraas);
                sisend = Console.ReadLine();
                sisestused.Add(sisend);
            } while (sisend != märksõna);
            return sisestused;
        }

        public void ArvaArv()
        {
            Random rnd = new Random();
            int salajane = rnd.Next(1, 101);
            int katseid = 0;
            bool arvatud = false;

            while (katseid < 5 && !arvatud)
            {
                Console.Write("Sisesta oma pakkumine (1-100): ");
                int pakkumine = int.Parse(Console.ReadLine());
                katseid++;
                if (pakkumine == salajane)
                {
                    Console.WriteLine("Õige!");
                    arvatud = true;
                }
                else if (pakkumine < salajane)
                {
                    Console.WriteLine("Liiga väike!");
                }
                else
                {
                    Console.WriteLine("Liiga suur!");
                }
            }
            if (!arvatud) Console.WriteLine("Ei arvanud ära. Vastus oli: " + salajane);
        }
    }

    public class Inimene
    {
        public string Nimi;
        public int Vanus;
    }
}