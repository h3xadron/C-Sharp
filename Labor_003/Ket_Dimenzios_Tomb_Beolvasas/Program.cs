using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ket_Dimenzios_Tomb_Beolvasas
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] T = new int[3, 3];
            Console.WriteLine("Add meg a számokat egy 3x3 táblához!");
            for (int i = 0; i < T.GetLength(0); i++) //Adatok bekérése Víszintes síkon 
            {
                for (int j = 0; j < T.GetLength(1); j++) // Adatok bekérése Függöleges síkon
                {
                    T[i,j] = int.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < T.GetLength(0); i++)// kiiratás 
            {
                Console.WriteLine();
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0} ", T[i, j])); // {0} nélkül is működik de így szebb a kimenet  {0} palceholder első objektumot adja vissza ami a T tömb a {1} a következtő változó lenne pl T[i,j], alma akkor almát írja ki.
                }
            }
            Console.ReadKey();


        }
    }
}
