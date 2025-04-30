using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.Praktiline_töö_Kangelane
{
    internal class Program
    {
        // Staatiline väli – hoiab kõiki loodud kangelasi
        static List<Kangelane> kangelased = new List<Kangelane>();

        // Staatiline meetod – loeb andmed failist ja täidab listi
        public static void LoeKangelasedFailist(string failinimi)
        {
            if (!File.Exists(failinimi))
            {
                Console.WriteLine("❌ Faili ei leitud: " + failinimi);
                return;
            }

            string[] read = File.ReadAllLines(failinimi);

            foreach (string rida in read)
            {
                string[] osad = rida.Split('/');
                if (osad.Length != 2) continue;

                string nimi = osad[0].Trim();
                string asukoht = osad[1].Trim();

                if (nimi.Contains("*"))
                {
                    nimi = nimi.Replace("*", "").Trim();
                    kangelased.Add(new SuperKangelane(nimi, asukoht));
                }
                else
                {
                    kangelased.Add(new Kangelane(nimi, asukoht));
                }
            }
        }

        // 🏁 Main – programmikäivitus
        public static void Main()
        {
            string failitee = "C:\\Users\\Admin\\Desktop\\visual studio работы\\C-alused\\Praktiline töö Kangelane\\andmed.txt";
            LoeKangelasedFailist(failitee);

            Console.WriteLine("Kangelased failist:\n");

            foreach (Kangelane k in kangelased)
            {
                Console.WriteLine(k.ToString());
                Console.WriteLine("Tervitus: " + k.Tervitus());
                Console.WriteLine("Riietus: " + k.Vormiriietus());
                Console.WriteLine("Staatus: " + k.MissiooniStaatus());
                Console.WriteLine("Päästetud (100 inimest): " + k.Paasta(100));
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}