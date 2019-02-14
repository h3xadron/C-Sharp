using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LittleNeptun.Adatkezeles
{
    public static class Fajlkezelo
    {
        public static Hallgato[] HallgatokBeolvasasa(string eleresiUt)
        {
            StreamReader sr = new StreamReader(eleresiUt);

            int hallgatokSzama = int.Parse(sr.ReadLine()); // Beolvasom a sorok számát a fájban.

            Hallgato[] hallgatok = new Hallgato[hallgatokSzama];

            for (int i = 0; i < hallgatok.Length; i++)
            {
                string nev = sr.ReadLine();
                string neptunazonosito = sr.ReadLine();
                int eletkor = int.Parse(sr.ReadLine());

                hallgatok[i] = new Hallgato(nev, neptunazonosito, eletkor);
            }
            sr.Close();

            return hallgatok;
        }

    }
}
