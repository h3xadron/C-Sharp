using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kisebb_Nagyobb_RandomSzam
{
    class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();
            int szam = R.Next(0, 101);
            Console.WriteLine(szam);

            Console.WriteLine("Gondoltam egy számra");
            int tipp;
            do
            {
                Console.WriteLine("mi a tipped?");
                tipp = int.Parse(Console.ReadLine());
                if (tipp > szam)
                {
                    Console.WriteLine("Kisebb a szám amire gondoltam");
                }
                if (tipp < szam)
                {
                    Console.WriteLine("Nagyobb a szám amire gondoltam");
                }
            } while (tipp != szam);
            Console.WriteLine("Eltaláltad a szám amire gondoltam: " + szam);
            Console.ReadLine();
        }
    }
}
