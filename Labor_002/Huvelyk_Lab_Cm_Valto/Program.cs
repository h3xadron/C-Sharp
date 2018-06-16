using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huvelyk_Lab_Cm_Valto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérlek add meg milyen típust akarsz átváltani! hüvelyk/láb");
            string TIPUS = Console.ReadLine();
            Console.WriteLine("Kérlek add meg a számot!");
            double ERTEK = double.Parse(Console.ReadLine());

            if (TIPUS == "hüvelyk" )
            {
                Console.WriteLine("Eredemény hüvelyből cm-re: " + (ERTEK * 2.54));
            }
            else
            {
                Console.WriteLine("Eredemény láb cm-re: " + (ERTEK * 30.48));
            }
            Console.ReadKey();

        }
    }
}
