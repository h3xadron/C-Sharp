using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Beadandó
{
    class Program
    {

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("visitors.txt");
            int elem = int.Parse(sr.ReadLine());
            sr.Close();
            int[,] visitors = new int[elem, 2];
            Feltoltes(visitors);
            Console.WriteLine("A beolvasott tömb kiírása: \n");
            Kiír(visitors);
            Console.WriteLine("A rendezett tömb: \n");
            Rendez(visitors);
            Console.WriteLine("Felügyelet Szükséges: \n");
            Esemeny(visitors);

            Console.ReadLine();

        }
        static int[,] Feltoltes(int[,] temp)
        {
            StreamReader sr = new StreamReader("visitors.txt");

            string line;
            int row = 0;
            int ossz = int.Parse(sr.ReadLine());
            while ((line = sr.ReadLine()) != null)
            {

                string[] rc = line.Split(' ');
                for (int col = 0; col < rc.Length; col++)
                {
                    temp[row, col] = int.Parse(rc[col]);
                }

                row += 1;
            }
            sr.Close();
            return temp;

        }

        static void Kiír(int[,] t)
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                Console.WriteLine(t[i, 0] + " " + t[i, 1]);
            }
        }

        static int[,] Esemeny(int[,] t)
        {
            /*int fullmax = 0;
            for (int i = 0; i < t.GetLength(0); i++)
            {
                if (t[i, 1] > fullmax)
                {
                    fullmax = t[i, 1];

                }

            }*/

            //    int[,] Empty = new int[t.GetLength(0), 2];
            int idx = 0;
            int db = 0;
            int elem = t.GetLength(0);
            int[,] tomb = new int[elem, 2];
            while (idx != t.GetLength(0))
            {

                int min = 2000, max = 0;
                for (int i = 0; i < t.GetLength(0); i++)
                {
                    if (t[i, 0] < min)
                    {
                        min = t[i, 0];
                        max = t[i, 1];
                    }

                }

                int seged = 1;
                while (seged <= t.GetLength(0) - 1)
                {
                    if ((t[seged, 0] >= min) && (t[seged, 0] <= max))
                    {
                        if (t[seged, 1] > max)
                        {
                            max = t[seged, 1];
                            idx = seged;
                            db++;

                        }
                    }
                    seged++;

                }




                tomb[db, 0] = min;
                tomb[db, 1] = max;
            }


            Console.WriteLine(tomb[0, 0] + " " + tomb[0, 1]);
            return tomb;
        }


        static int[,] Rendez(int[,] t)
        {
            int y;
            int z;
            for (int i = 0; i < t.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < t.GetLength(0); j++)
                {
                    if (t[i, 0] > t[j, 0])
                    {
                        y = t[i, 0];
                        z = t[i, 1];
                        t[i, 0] = t[j, 0];
                        t[i, 1] = t[j, 1];
                        t[j, 0] = y;
                        t[j, 1] = z;
                    }
                }


            }
            for (int i = 0; i < t.GetLength(0); i++)
            {

                Console.WriteLine(t[i, 0] + " " + t[i, 1]);


            }

            return t;
        }

    }


}