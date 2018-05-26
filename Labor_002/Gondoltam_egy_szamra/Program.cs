using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gondoltam_egy_szamra
{
    class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();
            int random_szam = R.Next(1, 10);
            Console.WriteLine(random_szam);
            int probalkozasok = 0;
            int tip;
            do
            {
                Console.WriteLine("Gondoltam egy számra!");
                tip = int.Parse(Console.ReadLine());
                if (tip > random_szam)
                {
                    Console.WriteLine("A szám kisebb");
                    probalkozasok++;
                }
                if (tip < random_szam)
                {
                    Console.WriteLine("A szám nagyobb");
                    probalkozasok++;
                }
                                             
            } while (tip != random_szam);

            Console.WriteLine("Gratulálok eltaláltad: " + random_szam + " Ennyi probálkozás után: " + probalkozasok);
            Console.ReadLine();
            
        }
    }
}
