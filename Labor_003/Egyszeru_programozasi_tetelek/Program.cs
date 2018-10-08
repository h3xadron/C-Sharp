using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyszeru_programozasi_tetelek
{
    class Program
    {
        static int[] RandomSzamGenerator()
        {
            Random R = new Random();
            int[] t = new int[10];
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = R.Next(0, 20);
            }
            return t;
        }
        static int TombOsszege(int[] T)     
        {
            int osszeg = 0;
            for (int i = 0; i < T.Length; i++)
            {
                osszeg += T[i];
            }
            return osszeg;
        }
        static void OttelOszthatoEesMiAzIndexe(int[] T)
        {
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] % 5 == 0)
                {
                    Console.WriteLine(T[i] + " Igen és az indexe a tömben " + i);
                }
                else
                {
                    Console.WriteLine("-1");

                }
            }
        }
        static int Megszamlalas(int[] T)
        {
            int db = 0;
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] % 5 == 0)
                {
                    db++;
                }
            }

            return db;
        }
        static int MaximumKivalasztas(int[] T)
        {
            int max = 0;
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] > max)
                {
                    max = T[i];
                }
            }
            return max;
        }
        static void Main(string[] args)
        {
            int[] T = RandomSzamGenerator();
            Console.WriteLine("A tömb elemei:");
            for (int i = 0; i < T.Length; i++)
            {
                Console.WriteLine(" " + T[i]);
            }
            Console.WriteLine("\nTömb elemeinek összege: " + TombOsszege(T) + "\n");
            Console.WriteLine("Osztható-e öttel a szám:");
            OttelOszthatoEesMiAzIndexe(T);
            Console.WriteLine("\nEnnyi darab szám osztható öttel: " + Megszamlalas(T));
            Console.WriteLine("\nEz a legnagyobb eleme a tömbnek: " + MaximumKivalasztas(T));
            Console.ReadKey();
        }
    }
}
