using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérlek add meg hagyadik elemét számoljam ki a Fibonacci sornak?");
            int input = int.Parse(Console.ReadLine());
            int a = 0;
            int b = 1;
            for (int i = 1; i < input; i++)
            {
                int divitsion = a;
                a = b;
                b = divitsion + b;
            }
            Console.WriteLine("Az eredmény: " + a);
            Console.ReadLine();
        }
    }
}
