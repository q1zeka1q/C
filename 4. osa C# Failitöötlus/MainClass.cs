using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused._4._osa_C__Failitöötlus
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            // 1. Kirjuta 3 kuud faili
            FunktsioonideClass.KirjutaKuudFaili();

            // 2. Loe kuud listi
            List<string> kuud = FunktsioonideClass.LoeKuudFailist();

            // 3. Kuva kuud
            FunktsioonideClass.KuvadaKuud(kuud);

            // 4. Eemalda Juuni, muuda esimene
            FunktsioonideClass.EemaldaJuuniJaMuudaEsimene(kuud);

            // 5. Kuva uuesti
            Console.WriteLine("\nMuudetud kuud:");
            FunktsioonideClass.KuvadaKuud(kuud);

            // 6. Otsi kuud
            FunktsioonideClass.OtsiKuu(kuud);

            // 7. Salvesta muudatused
            FunktsioonideClass.SalvestaKuud(kuud);
        }
    }
}