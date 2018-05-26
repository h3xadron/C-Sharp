using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamlologep
{
    class Program
    {
        static void Main(string[] args)
        {
            int eredmeny;
            Console.WriteLine("Kérlek add meg két számot meg egy műveleti jelet");
            int szam01 = int.Parse(Console.ReadLine());
            int szam02 = int.Parse(Console.ReadLine());         
            string muveletijel =Console.ReadLine();
            switch (muveletijel)
            {
                case "-":
                    eredmeny = szam01 - szam02;
                    break;
                case "*":
                    eredmeny = szam01 * szam02;
                    break;
                case "/":
                    eredmeny = szam01 / szam02;
                    break;
                default:
                    eredmeny = szam01 + szam02;
                    break;
            }
            Console.WriteLine(eredmeny);
            Console.ReadLine();
        }
    }
}
