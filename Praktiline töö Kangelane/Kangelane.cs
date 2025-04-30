using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.Praktiline_töö_Kangelane
{
    public class Kangelane
    {
        //  Privaatväljad
        private string nimi;
        private string asukoht;

        //  Konstruktor
        public Kangelane(string nimi, string asukoht)
        {
            this.nimi = nimi;
            this.asukoht = asukoht;
        }

        //  Omadused
        public string Nimi
        {
            get { return nimi; }
            set { nimi = value; }
        }

        public string Asukoht
        {
            get { return asukoht; }
            set { asukoht = value; }
        }

        // Meetodid
        public virtual int Paasta(int ohus)
        {
            return (int)Math.Round(ohus * 0.95);
        }

        public virtual string Vormiriietus()
        {
            return "Standardne kangelase vormiriietus: keep ja mask.";
        }

        public virtual string Tervitus()
        {
            return $"Tere! Mina olen {nimi}, sinu kaitsja linnas {asukoht}!";
        }

        public virtual string MissiooniStaatus()
        {
            return "Kangelane on valmis missiooniks!";
        }

        public override string ToString()
        {
            return $"Kangelane {nimi}, tegutseb linnas {asukoht}.";
        }
    }
}
