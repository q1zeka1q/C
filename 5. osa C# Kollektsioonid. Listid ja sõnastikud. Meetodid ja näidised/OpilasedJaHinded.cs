using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused._5._osa_C__Kollektsioonid._Listid_ja_sõnastikud._Meetodid_ja_näidised
{
    class Õpilane
    {
        public string Nimi { get; set; }
        public List<int> Hinded { get; set; }

        public Õpilane(string nimi)
        {
            Nimi = nimi;
            Hinded = new List<int>();
        }

        public double Keskmine()
        {
            return Hinded.Count > 0 ? Hinded.Average() : 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Õpilane> õpilased = new List<Õpilane>();

            Console.Write("Mitu õpilast soovid lisada? ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 1)
            {
                Console.WriteLine("Vale sisend.");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write($"\nSisesta õpilase #{i + 1} nimi: ");
                string nimi = Console.ReadLine();
                var õpilane = new Õpilane(nimi);

                Console.Write($"Mitu hinnet sisestada (3–5)? ");
                int hinneArv = Math.Clamp(int.Parse(Console.ReadLine()), 3, 5);

                for (int j = 0; j < hinneArv; j++)
                {
                    Console.Write($"Hinne {j + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int hinne))
                        õpilane.Hinded.Add(hinne);
                }

                õpilased.Add(õpilane);
            }

            Console.WriteLine("\n--- ÕPILASTE TULEMUSED ---");
            foreach (var õp in õpilased)
                Console.WriteLine($"{õp.Nimi} - keskmine: {õp.Keskmine():F2}");

            var parim = õpilased.OrderByDescending(o => o.Keskmine()).First();
            Console.WriteLine($"\nKõrgeim keskmine hinne on {parim.Keskmine():F2}, saanud õpilane: {parim.Nimi}");

            Console.WriteLine("\n--- Sorteeritud keskmise hinde järgi ---");
            foreach (var õp in õpilased.OrderBy(o => o.Keskmine()))
                Console.WriteLine($"{õp.Nimi}: {õp.Keskmine():F2}");
        }
    }
}

