using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyv_Peldak
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] T = new int[10];
            Random R = new Random();
            for (int i = 0; i < T.Length; i++)
            {
                T[i] = R.Next(0, 20);
                Console.WriteLine(T[i]);
            }
            /*
            foreach (var elem in T)
            {
                Console.WriteLine(elem);
            }
            Console.ReadKey();
            */
        }
    }
}
