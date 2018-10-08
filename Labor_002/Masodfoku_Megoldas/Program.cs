using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masodfoku_Megoldas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add meg a a b c értékeit: ");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double gyokalattiresz = b * b - 4 * a * c;
            Console.WriteLine("Az eredmény: " + (b + Math.Sqrt(gyokalattiresz)) / (2 * a));
            Console.ReadKey();
        }
    }
}
