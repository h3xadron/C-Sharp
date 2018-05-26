using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hallgato_nevenek_bekerese
{
    class Program
    {
        static void Main(string[] args)
        {
            string name ="";          
            do
            {
                Console.WriteLine("Kérlek add meg a neved!");
                name = Console.ReadLine();
            } while (((name == "") || (name == "Robi")));
            Console.Write("Ezt adtad meg: " + name);
            Console.ReadLine();
        }
    }
}

