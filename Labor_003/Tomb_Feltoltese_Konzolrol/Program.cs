using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomb_Feltoltese_Konzolrol
{
    class Program
    {
        static void Main(string[] args)
        {
            int db = 10;
            int[] T = new int[10];
            Console.WriteLine("Adj meg 10 db számot!");
            for (int i = 0; i < T.Length; i++)
            {
                Console.WriteLine("Mi a szám!");
                T[i] = int.Parse(Console.ReadLine());
                db--;
                Console.WriteLine("Még ennyi kell " + db);
            }
            Console.WriteLine("\nEzeket a számokat adtad meg:");
            for (int i = 0; i < T.Length; i++)
            {
                Console.WriteLine(T[i]);
            }
            Console.ReadKey();
            
        }
    }
}
