using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace C_alused
{
    class FunktsioonideClass
    {
        //public static float Kalkulaator(int arv1, int arv2)
        //{
        //    float kalkulaator = 0;
        //    kalkulaator = arv1 * arv2;
        //    return kalkulaator;
        //}

        //public static string switchKasuta(int a)
        //{
        //    string tekst;

        //    switch (a)
        //    {
        //        case 1: tekst = "Esmaspäev"; break;
        //        case 2: tekst = "Teisipäev"; break;
        //        case 3: tekst = "Kolmapäev"; break;
        //        case 4: tekst = "Neljapäev"; break;
        //        case 5: tekst = "Reede"; break;
        //        case 6: tekst = "Laupäev"; break;
        //        case 7: tekst = "Pühapäev"; break;

        //        default:
        //            tekst = "Tundmatu";
        //            break;
        //    }
        //    return tekst;
        //}
        public static string pinginaabrid(string nimi1, string nimi2)
        {
            string vastus;
            if (nimi1 == nimi2)
            {
                vastus = "Sa sisestasid sama nime kaks korda.";
            }
            else
            {
                vastus = nimi1 + " ja " + nimi2 + " on pinginaabrid.";
            }   
            return vastus;
        }
        public static double korutamine(double a, double b)
        {
            double vastus = a * b;
            return vastus;
        }
        public static double korutamine(double a, double b)
        {

        }

    }
}
