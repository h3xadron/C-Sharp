using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_Max_Kivalasztas
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 100;
            int minidx = -1;
            int max = -10;
            int maxidx = -1;
            int[] _Tomb = new int[5];
            Random random = new Random();
            for (int i = 0; i < _Tomb.Length; i++)
            {
                _Tomb[i] = random.Next(20);
                Console.Write(string.Format("{0} ", _Tomb[i]));
            }
            for (int i = 1; i < _Tomb.Length; i++)
            {
                if (_Tomb[i] > max )
                {
                    max = _Tomb[i];
                    maxidx = i;
                }
                if (_Tomb[i] < min)
                {
                    min = _Tomb[i];
                    minidx = i;
                }
            }
            Console.WriteLine("\nA legkisebb eleme a tömbnek: " + min + " " + minidx);
            Console.WriteLine("\nA legnagyobb eleme a tömbnek: " + max +" " + maxidx);

            Console.ReadKey();
        }
    }
}
