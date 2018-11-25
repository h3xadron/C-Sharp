using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Island
{
    class Program
    {
        static void Main(string[] args) 
        {
            int szigetek_szama = 0;
            int szigethossz = 0;
            int i = 0;

            int[] _Tomb = new int[10];
            Random random = new Random();
            for (i = 0; i < _Tomb.Length; i++)
            {
                _Tomb[i] = random.Next(0, 1);
                Console.WriteLine(_Tomb[i]);
            }
            while (i < _Tomb.Length)
            {
                if (_Tomb[i] == 1)
                {
                    szigetek_szama++;
                    int seged = 0;
                    int j = i;

                    while (j < _Tomb.Length && _Tomb[j] == 1)
                    {
                        j++;
                        seged++;
                    }
                    i = j;
                    if (seged > szigethossz)
                    {
                        szigethossz = seged;
                    }

                }
                else
                    i++;
                Console.ReadKey();
            }

            /*
            for (int i = 0; i < _Tomb.Length; i++)
            {
                if (_Tomb[i] == 1)
                {
                    szigetek_szama++;
                }
                if (true)
                {

                }
            }*/

        }
    }
}
