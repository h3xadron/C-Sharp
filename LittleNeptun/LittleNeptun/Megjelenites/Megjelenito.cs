using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleNeptun.Megjelenites
{
    public static class Megjelenito
    {
        public static void HallgatoMegjelenitese(Hallgato[] hallgatok)
        {
            for (int i = 0; i < hallgatok.Length; i++)
            {
                Console.WriteLine("Hallgató neve:\t\t{0}\nNeptunkódja:\t\t{1}\nÉletkora:\t\t{2}\n", hallgatok[i].Nev, hallgatok[i].Neptunkod, hallgatok[i].Eletkor);
            }
        }
    }
}
