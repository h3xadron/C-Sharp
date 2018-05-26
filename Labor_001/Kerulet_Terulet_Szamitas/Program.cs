using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerulet_Terulet_Szamitas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérem A és B oldal hosszát!");
            int Aoldal = int.Parse(Console.ReadLine());
            int Boldal = int.Parse(Console.ReadLine());
            Console.WriteLine("A téglalap kerülete: " + Aoldal * Boldal + ". Kerülete: " + (2*(Aoldal + Boldal)) + ".");
            Console.ReadLine();
        }
    }
}
