﻿using System;
using System.Collections.Generic;
using System.IO;

namespace C_alused.Praktiline_töö_Kangelane
{
    class Program
    {
        // список всех героев
        static List<Kangelane> kangelased = new List<Kangelane>();

        // метод для добавления героя в список и чтения файла
        static void LoeKangelasedFailist(string failinimi)
        {
            try
            {
                foreach (string rida in File.ReadAllLines(failinimi))
                {
                    string[] andmed = rida.Split('/');
                    string nimi = andmed[0];
                    string asukoht = andmed[1];

                    if (nimi.Contains("*"))
                    {
                        nimi = nimi.Replace("*", "");
                        kangelased.Add(new SuperKangelane(nimi, asukoht));
                    }
                    else
                    {
                        kangelased.Add(new Kangelane(nimi, asukoht));
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga, ei saa faili lugeda");
            }
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\Admin\Desktop\visual studio работы\C-alused\Praktiline töö Kangelane\andmed.txt";
            LoeKangelasedFailist(path);

            foreach (Kangelane kangelane in kangelased)
            {
                // Определяем тип героя
                if (kangelane is SuperKangelane superkangelane)
                {
                    Console.WriteLine("\n--- Superkangelane ---");
                    Console.WriteLine(superkangelane.ToString());
                    Console.WriteLine("Päästetud (1000): " + superkangelane.Paasta(1000));
                    Console.WriteLine("Riietus: " + superkangelane.Vormiriietus());
                    Console.WriteLine("Tervitus: " + superkangelane.Tervitus());
                    Console.WriteLine("Staatus: " + superkangelane.MissiooniStaatus());
                }
                else
                {
                    Console.WriteLine("\n--- Tavakangelane ---");
                    Console.WriteLine(kangelane.ToString());
                    Console.WriteLine("Päästetud (1000): " + kangelane.Paasta(1000));
                    Console.WriteLine("Riietus: " + kangelane.Vormiriietus());
                    Console.WriteLine("Tervitus: " + kangelane.Tervitus());
                    Console.WriteLine("Staatus: " + kangelane.MissiooniStaatus());
                }
            }

            Console.ReadKey();
        }

    }
}

