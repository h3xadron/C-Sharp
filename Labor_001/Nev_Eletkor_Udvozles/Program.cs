using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nev_Eletkor_Udvozles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérlek add meg a neved!");
            string Name = Console.ReadLine();
            Console.WriteLine("Kérlek add meg az életkorodat!");
            int Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Szia " + Name + "! Aki " + Age + "éves.");
            Console.ReadLine();

        }
    }
}
