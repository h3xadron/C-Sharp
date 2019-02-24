using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek.Jatekter
{
    class JatekTer
    {
        const int MAX_ELEMSZAM = 1000;

        private int elemN;
        private JatekElem[] elemek; // ez most miért max_elemszám méretű így?!

        private int meretX;
        public int MeretX { get { return meretX; } }

        private int meretY;
        public int MeretY { get { return meretY; } }

        public JatekTer(int meretX, int meretY)
        {
            this.meretY = meretX;
            this.meretY = meretY;
        }

        public void Felvetel(JatekElem elemek) // ha nincs típus megadva akkor void?
        {
            
            elemN++;

        }

        public void Torol(JatekElem elemek)
        {
            elemN--;
        }

        public JatekElem[] MegadottHelyenLevok(int x, int y, int tavolsag)
        {

            return JatekElem[]
        }


    }
}
