using System;

namespace Pirate
{
    class MainClass
    {

        public static int[,] GenerateMap()
        {
            int[,] map = new int[22, 13];

            for (int i = 0; i < map.GetLength(0); i++) //sor
            {
                for (int j = 0; j < map.GetLength(1); j++) //oszlop
                {
                    Random r = new Random();
                    int randomszam = r.Next(0, 101);
                    if (randomszam < 20)
                    {
                        if (CheckNeighbours(map, i, j) == false)
                        {
                            Random _RandomKincs = new Random();
                            map[i, j] = _RandomKincs.Next(50, 201);
                        }
                        else
                        {
                            Random _VanSzomszedosKincs = new Random();
                            map[i, j] = _VanSzomszedosKincs.Next(10, 40);
                        }
                        int treasureAmmount = +map[i, j];
                    }

                }
            }
            return map;           
        }
        static bool CheckNeighbours(int[,] map, int i, int j)
        {
            //Ez a tömb bal szélső elemeit vizsgálja
            if (i == 0 && map[i, j + 1] == 0 && map[i + 1, j] == 0 && map[i + 1, j + 1] == 0) // ez a bal felső sarkot nézi és annak szomszédjait 
            {
                return false;
            }
            else if (j == map.Length && map[i, j - 1] == 0 && map[i - 1, j - 1] == 0 && map[i + 1, j] == 0) // a  tömb jobb felső sakát nézi
            {
                return false;
            }
            // ez mátrix bal középen lévő elemek szomszédait nézi
            if (i > 0 && map[i - 1, j] == 0 && map[i - 1, j + 1] == 0 && map[i, j + 1] == 0 && map[i + 1, j] == 0 && map[i + 1, j + 1] == 0) 
            {
                return false;
            }
            else if (j == map.Length && map[i - 1, j] == 0 && map[i - 1, j - 1] == 0 && map[i, j - 1] == 0 && map[i + 1, j - 1] == 0 && map[i + 1, j] == 0) // Mátrix  jobb  szélén lévő középső elemekt nézi
            {
                return false;
            }
            // Mátrix bal alsó sarkát nézi
            if (i == map.Length && map[i - 1, j] == 0 && map[i - 1, j + 1] == 0 && map[i, j + 1] == 0) 
            {
                return false;

            }
            else if (j == map.Length && map[i - 1, j] == 0 && map[i - 1, j - 1] == 0 && map[i, j - 1] == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static void Draw(int[,] map)
        {
            for (int i = 0; i < 99; i++)
            {
                Console.Write("*");
            }
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j] + "\t");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < 99; i++)
            {
                Console.Write("*");
            }
        }

        static void HideTreasure(int[,] map, int treasureAmmount)
        {
            Random r = new Random();
            int SOR_Random_Rejtek_Hely = r.Next(0, 23);
            int OSZLOP_Random_Rejtek_Hely = r.Next(0, 13);
            int OSSSZEG = r.Next(100, 151);
            int db = 0;
            for (int i = 0; i < treasureAmmount; i++)
            {
                db++;
                if (map[SOR_Random_Rejtek_Hely, OSZLOP_Random_Rejtek_Hely] == 0 && db !=10)
                {
                        map[SOR_Random_Rejtek_Hely, OSZLOP_Random_Rejtek_Hely] = treasureAmmount - OSSSZEG;
                } 
                else if (map[SOR_Random_Rejtek_Hely, OSZLOP_Random_Rejtek_Hely] == 0)
                {
                    map[SOR_Random_Rejtek_Hely, OSZLOP_Random_Rejtek_Hely] = treasureAmmount;
                }
            }
        }

        public static void Main(string[] args)
        {
            int[,] Palya = GenerateMap();
            Draw(Palya);
            HideTreasure()
            Console.ReadKey();


        }
    }
}