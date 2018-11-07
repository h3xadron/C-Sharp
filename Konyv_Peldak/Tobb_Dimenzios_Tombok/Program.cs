using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tobb_Dimenzios_Tombok
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Matrix = new int[3, 3];
            Random R = new Random();
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = R.Next(0, 100);
                    Console.Write(String.Format("{0}, ", Matrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);

            }
            Console.ReadLine();

        }
    }
}
