using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused._5._osa_C__Kollektsioonid._Listid_ja_sõnastikud._Meetodid_ja_näidised
{
    internal class MaakonnadJaPealinnad
    {
        static Dictionary<string, string> maakonnad = new Dictionary<string, string>()
        {
            { "Harjumaa", "Tallinn" },
            { "Tartumaa", "Tartu" },
            { "Pärnumaa", "Pärnu" },
            { "Ida-Virumaa", "Jõhvi" },
            { "Lääne-Virumaa", "Rakvere" }
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- MENÜÜ ---");
                Console.WriteLine("1. Leia pealinn maakonna järgi");
                Console.WriteLine("2. Leia maakond pealinna järgi");
                Console.WriteLine("3. Lisa uus maakond ja pealinn");
                Console.WriteLine("4. Mängu režiim");
                Console.WriteLine("5. Välju");
                Console.Write("Valik: ");
                string valik = Console.ReadLine();

                switch (valik)
                {
                    case "1":
                        LeiaPealinn();
                        break;
                    case "2":
                        LeiaMaakond();
                        break;
                    case "3":
                        LisaUus();
                        break;
                    case "4":
                        Mangureziim();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Tundmatu valik!");
                        break;
                }
            }
        }

        static void LeiaPealinn()
        {
            Console.Write("Sisesta maakonna nimi: ");
            string maakond = Console.ReadLine();
            if (maakonnad.ContainsKey(maakond))
                Console.WriteLine($"Pealinn: {maakonnad[maakond]}");
            else
                Console.WriteLine("Sellist maakonda pole.");
        }

        static void LeiaMaakond()
        {
            Console.Write("Sisesta pealinna nimi: ");
            string pealinn = Console.ReadLine();
            string? maakond = maakonnad.FirstOrDefault(x => x.Value.Equals(pealinn, StringComparison.OrdinalIgnoreCase)).Key;
            if (maakond != null)
                Console.WriteLine($"Maakond: {maakond}");
            else
                Console.WriteLine("Sellise pealinnaga maakonda pole.");
        }

        static void LisaUus()
        {
            Console.Write("Sisesta uus maakond: ");
            string uusMaakond = Console.ReadLine();
            Console.Write("Sisesta selle pealinn: ");
            string uusPealinn = Console.ReadLine();

            if (!maakonnad.ContainsKey(uusMaakond))
            {
                maakonnad.Add(uusMaakond, uusPealinn);
                Console.WriteLine("Lisatud!");
            }
            else
            {
                Console.WriteLine("See maakond juba eksisteerib.");
            }
        }

        static void Mangureziim()
        {
            Console.WriteLine("--- Mängu režiim ---");
            int õige = 0;
            int kogus = 3;
            var rnd = new Random();
            var keys = maakonnad.Keys.ToList();

            for (int i = 0; i < kogus; i++)
            {
                string maakond = keys[rnd.Next(keys.Count)];
                Console.Write($"Mis on {maakond} pealinn? ");
                string vastus = Console.ReadLine();

                if (vastus.Equals(maakonnad[maakond], StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Õige!");
                    õige++;
                }
                else
                {
                    Console.WriteLine($"Vale. Õige vastus on {maakonnad[maakond]}.");
                }
            }

            double protsent = (double)õige / kogus * 100;
            Console.WriteLine($"Tulemus: {õige}/{kogus} ({protsent:F1}%)");
        }
    }
}
