using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hatvany_Faktorialis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("adj értéket");
            int szam = int.Parse(Console.ReadLine());
            int hatvany_szam = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Pow(szam, hatvany_szam));
            Console.WriteLine("Faktoriális: " )



        }
    }
}
