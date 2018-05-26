using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celsius_To_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérem adja meg a °C-ban az értéket");
            float celsius = float.Parse(Console.ReadLine());
            Console.WriteLine("Ez az érték Fahrenheit-ben: " + ((celsius*1.8)+23));
            Console.ReadLine();
        }
    }
}
