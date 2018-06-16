using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNKO_LKKT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérlek adj meg két számot!");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int r = (a / b);
            do
            {
                a = b;
                b = r;
                r = (a / b);

            } while (r !=0);
            Console.WriteLine(b);
            Console.ReadKey();


//TODO nincs most kedvem befejezni 
        }
    }
}
