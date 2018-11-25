using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macska_OOP
{
    class Macska
    {
        public int sorszam;
        public int suly;
        public int eletkor;

        public void Kiiratas()
        {
            // Console.WriteLine(sorszam + " " + suly + " " + eletkor);
            Console.WriteLine($"Macska adatai: {sorszam} suly: {suly} eletkor: {eletkor}");
        }

        public Macska(int sorszam, int suly, int eletkor) //konstruktor paraméterekkel
        {
            this.sorszam = sorszam;
            this.suly = suly;
            this.eletkor = eletkor;
        }
        public Macska() // Üres konsruktor csak akkor kell ha paraméternélkülit akarok.
        {
        }

        /**
         * Felesleges mivel GC megoldja (logolásra jó :) ) 
        ~Macska()//Desruktor 
        {
            Console.WriteLine("Takarítva");
        }**/
    }
}
