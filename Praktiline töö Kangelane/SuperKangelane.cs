using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.Praktiline_töö_Kangelane
{
    public class SuperKangelane : Kangelane
    {
        // Lisaomadus
        public double Osavus { get; }

        private static readonly Random rnd = new Random();

        // Konstruktor
        public SuperKangelane(string nimi, string asukoht) : base(nimi, asukoht)
        {
            // Osavus väärtus vahemikus [1.0, 5.0)
            Osavus = Math.Round(1.0 + rnd.NextDouble() * 4.0, 2);
        }

        // Meetodite override’id

        public override int Paasta(int ohus)
        {
            double päästetudProtsent = 95.0 + Osavus;
            int päästetud = (int)Math.Round(ohus * (päästetudProtsent / 100));
            return päästetud;
        }

        public override string Vormiriietus()
        {
            return "Superkangelase kostüüm: kõrgtehnoloogiline armor ja lendav keep.";
        }

        public override string Tervitus()
        {
            return $"Tere, maailm! Super-{Nimi} on siin, et päästa linn {Asukoht}!";
        }

        public override string MissiooniStaatus()
        {
            return "Superkangelane on juba missioonil – palun oota!";
        }

        public override string ToString()
        {
            return base.ToString() + $" (Osavus: {Osavus:F2})";
        }
    }
}
