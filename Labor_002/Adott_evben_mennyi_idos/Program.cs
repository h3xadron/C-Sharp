using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adott_evben_mennyi_idos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mi a neved?");
            string Name = Console.ReadLine();
            Console.WriteLine("Milyen évet írunk?");
            int Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Mikor születtél?");
            int Date = int.Parse(Console.ReadLine());
            Console.WriteLine("Szia " + Name + "! Ennyi idős vagy: " + (Year - Date));
            Console.ReadLine();

        }
    }
}
