using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleNeptun.Adatkezeles;
using LittleNeptun.Megjelenites;

namespace LittleNeptun
{
    public class Neptun
    {
        private string hallgatokEleresiUtja = "hallgato.txt";

        private Hallgato[] hallgatok;

        public Neptun()
        {
            hallgatok = new Hallgato[13];
            HallgatokBeolvasasaFajlbol();
            HallgatoMegjelenitese();
        }
        private void HallgatokBeolvasasaFajlbol()
        {
            hallgatok = Fajlkezelo.HallgatokBeolvasasa(hallgatokEleresiUtja);
        }
        private void HallgatoMegjelenitese()
        {
            Megjelenito.HallgatoMegjelenitese(hallgatok);
        }
    }
}
