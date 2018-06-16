using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanyadik_Perce_A_Napnak
{
    class Program
    {
        static void Main(string[] args)
        {
            string time = DateTime.Now.ToShortTimeString();
            string[] subString = time.Split(':');
            int eredmeny = ((int.Parse(subString[0]) * 60) + int.Parse(subString[1]));
            Console.WriteLine(eredmeny);
            Console.ReadLine();
        }
    }
}
