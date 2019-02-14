using System;

namespace Pirate
{
    class MainClass
    {
        public int[,] GenerateMap()
        {
            int[,] map = new int[22, 13];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Random r = new Random();
                    int randomszam = r.Next(0, 101);
                    if (randomszam < 20)
                    {
                        if (CheckNeighbours(true))
                        {
                            Random _RandomKincs = new Random();
                            map[i, j] = _RandomKincs.Next(50, 201);
                        }
                    }

                }
            }


        }

        bool CheckNeighbours(int[,] map, int i, int j)
        {

            if (map[0, j] == 0 || map[0, j - 1] == 0 || map[0, j + 1] == 0 || map[i, 0] == 0 || map[i + 1, 0] == 0 || map[i - 1, 0] == 0)
            {
                return false;
            }
            if (map[i - 1, j - 1] == 0 || map[i - 1, j + 1] == 0 || map[i - 1, j] == 0 || map[i + 1, j] == 0 || map[i + 1,j + 1] == 0 || map[i + 1, j - 1] == 0 || )
            {

                return false;
            }
            else
            {
                return true;
            }


        }
            if ( ||  || map[i - 1, j + 1] || map[i, j - 1] || map[i, j + 1] || map[i + 1, j - 1] map[i + 1, j] || map[i + 1, j + 1])
                    {


            }
        }
    }

}

public static void Main(string[] args)
{
    Console.WriteLine("Hello World!");
}
    }
}
