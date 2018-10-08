using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beirt_Szam_Atlaga_Negativ_Esetén
{
    class Program
    {
        static void Main(string[] args)
        {
            int szam;
            int sum=0;
            int counter=0;
            Console.WriteLine("Adjon meg számokat ha negatívat add meg akkor átlagot számol");
            do
            {
                szam =int.Parse(Console.ReadLine());
                sum+=szam;
                counter+= 1;
            } while (szam > 0 );
            Console.Write("Negatív számot adtál meg az eddig megadott számok átlaga: " + sum / counter);
            Console.ReadKey();
        }
    }
}
