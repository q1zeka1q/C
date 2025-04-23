using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused._5._osa_C__Kollektsioonid._Listid_ja_sõnastikud._Meetodid_ja_näidised
{
    internal class ArvudeStatistika
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sisesta arvud eraldatuna tühikuga (nt 5 3 8 1):");
            double[] arvud = TekstistArvud(Console.ReadLine());

            if (arvud.Length == 0)
            {
                Console.WriteLine("Pole ühtegi kehtivat arvu!");
                return;
            }

            Console.WriteLine($"\nMaksimum: {arvud.Max()}");
            Console.WriteLine($"Miinimum: {arvud.Min()}");
            Console.WriteLine($"Keskmine: {arvud.Average():F2}");
            Console.WriteLine($"Kogusumma: {arvud.Sum()}");

            double keskmine = arvud.Average();
            int suuremadKuiKeskmine = arvud.Count(x => x > keskmine);
            Console.WriteLine($"Arve, mis on suuremad kui keskmine: {suuremadKuiKeskmine}");

            Console.WriteLine("\nSorteeritud arvud:");
            Array.Sort(arvud);
            foreach (var arv in arvud)
            {
                Console.Write(arv + " ");
            }
            Console.WriteLine();
        }

        static double[] TekstistArvud(string sisend)
        {
            string[] osad = sisend.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            return osad
                .Select(s =>
                {
                    if (double.TryParse(s.Replace(',', '.'), out double tulemus))
                        return tulemus;
                    else
                        return double.NaN;
                })
                .Where(x => !double.IsNaN(x))
                .ToArray();
        }
    }
}
