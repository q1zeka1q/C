using System;
using System.Collections.Generic;
using System.IO;

namespace C_alused.Praktiline_töö_Kangelane
{
    internal class Program
    {
        // Статическое поле – список всех героев
        static List<Kangelane> kangelased = new List<Kangelane>();

        // Метод для чтения из файла
        public static void LoeKangelasedFailist(string failinimi)
        {
            if (!File.Exists(failinimi))
            {
                Console.WriteLine("Faili ei leitud: " + failinimi);
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


        public static void Main()
        {
            string failitee = "C:\\Users\\Admin\\Desktop\\visual studio работы\\C-alused\\Praktiline töö Kangelane\\andmed.txt";
            LoeKangelasedFailist(failitee);

            Kangelane tavakangelane = null;
            SuperKangelane superkangelane = null;

            foreach (Kangelane k in kangelased)
            {
                if (tavakangelane == null && k is Kangelane && !(k is SuperKangelane))
                    tavakangelane = k;
                else if (superkangelane == null && k is SuperKangelane)
                    superkangelane = (SuperKangelane)k;

                if (tavakangelane != null && superkangelane != null)
                    break;
            }

            Console.WriteLine("TAVAKANGELANE\n");

            if (tavakangelane != null)
            {
                Console.WriteLine(tavakangelane.ToString());
                Console.WriteLine("Päästetud (1000): " + tavakangelane.Paasta(1000));
                Console.WriteLine("Riietus: " + tavakangelane.Vormiriietus());
                Console.WriteLine("Tervitus: " + tavakangelane.Tervitus());
                Console.WriteLine("Staatus: " + tavakangelane.MissiooniStaatus());
            }
            else
            {
                Console.WriteLine("Tavakangelast ei leitud!");
            }

            Console.WriteLine("\nSUPERKANGELANE\n");

            if (superkangelane != null)
            {
                Console.WriteLine(superkangelane.ToString());
                Console.WriteLine("Päästetud (1000): " + superkangelane.Paasta(1000));
                Console.WriteLine("Riietus: " + superkangelane.Vormiriietus());
                Console.WriteLine("Tervitus: " + superkangelane.Tervitus());
                Console.WriteLine("Staatus: " + superkangelane.MissiooniStaatus());
            }
            else
            {
                Console.WriteLine("Superkangelast ei leitud!");
            }
        }
    }
}
