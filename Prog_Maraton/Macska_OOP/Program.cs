using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macska_OOP
{

    class Program
    {
        public Macska[] Macska_Feldolgozás()
        {

            Macska[] macska_tomb = new Macska[30];
            for (int i = 0; i < macska_tomb.Length; i++)
            {
                Macska peldany = new Macska(i, R.Next(1, 30), R.Next(30, 40));
                macska_tomb[i] = peldany;
                peldany.Kiiratas();
            }
            return macska_tomb;

        }

        static int Max_Macska(int[] Tomb_Macska)
        {
            for (int i = 0; i < Tomb_Macska.Length; i++)
            {
                int seged = Tomb_Macska[i];
                if (true)
                {

                }

            }
   





        }

        static Random R = new Random();
        static void Main(string[] args)
        {

            Console.ReadLine();
        }

            /** MEGJEGYZÉS:
             * deklarálni kéne egy tömböt ami 30 elemű utána a ciklus a példányt folyton meghívni és úgy végig iterálni a tömbön és feltölteni az értékekkel
             * random generátor is kéne a számok felsorolásához.*/



            /*Random R = new Random();
            int[] Macska_Tomb = new int[30];
            for (int i = 0; i < Macska_Tomb.Length; i++)
            {
                int sorszam++;
                int suly = R.Next(1, 10);
                int eletkor = R.Next(20, 40);
                Macska peldany = new Macska();
                peldany.Macska(sorszam, suly, eletkor);
            }

            Console.WriteLine(peldany)*/
             


        
    }
}
