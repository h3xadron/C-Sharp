using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleNeptun
{
    public  class Hallgato
    {
        #region Adattagok, tulajdonságok helye
        public string Nev { get; set; }
        public string Neptunkod { get; set; }
        public int Eletkor { get; set; }
        #endregion

        #region Konstruktor
        public Hallgato() // Ez paraméter nélküli konsruktor mivel a Hallgató()  zárójelében nincs felsorolva változó. Ilyenkor a benne felsorolt értékekkel jön létre az példány
        {
            Nev = "Nincs Megadv";
            Neptunkod = "ASD123";
            Eletkor = -1;
        }

        public Hallgato(string nev, string neptunazonosito, int eletkor) // Ez a kapot paraméterek szerint állítja be az értékeket
        {
            this.Nev = nev;
            this.Neptunkod = neptunazonosito;
            this.Eletkor = eletkor;

        }
        #endregion
    }
}