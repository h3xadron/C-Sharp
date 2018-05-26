using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulon_kulon_koszones
{
    class Program
    {
        static void Main(string[] args)
        {
            string koszones;
            string name = Console.ReadLine();
            switch (name)
            {
                case "béla":
                    koszones = "Szia";
                    break;
                case "Bill":
                    koszones = "A király!";
                    break;
                case "Joe":
                    koszones = "Szevasz!";
                    break;
                case "Maldini":
                    koszones = "Ciao!";
                    break;
                default:
                    koszones = "Hello";
                    break;
            }
            Console.WriteLine(koszones);
            Console.ReadLine();
        }
    }
}
