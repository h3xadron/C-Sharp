using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombel_valo_jatek
{
    class Program
    {
       
     /*     
        Hozzon létre egy 10 elemű tömböt, majd töltse fel random számokkal 100-ig.
        Számolja ki a tömbök elemeinek összegét.
        A tömb elemeinek 2x-esét tárolja el egy másik tömbben.

        Nézze meg, hogy van e a tömbben olyan szám ami 40 és 50 között található.
        Rendezze a tömb elemeit csökkenő sorrendben és tárolja el egy másik tömbben.
     */

        static int[] RandomTombGenerator()
        {
            Random R = new Random();
            int[] t = new int[10];
            for (int i = 0; i < t.Length; i++)
			{
                t[i]= R.Next(1,100);
			}
            return t;
        }
        static int TombOsszege(int[] Tomb)
        {
            int ERTEK;
            for (int i = 0; i < Tomb.Length; i++)
			{
                ERETEK =+ Tomb[i];
			}
            return ERTEK;
        }
        static int TombErtekeinekaKetszerese(int[] Tomb)
        {
            int[] TombKetszerese = new int[10];

            for (int i = 0; i < Tomb.Length; i++)
		    {
                for (int j = 0; i < TombErtekeinekaKetszerese.Length; i++)
    			{
                    TombErtekeinekaKetszerese[j] = (Tomb[i] * 2);
	    		}
		    }
            return TombErtekeinekaKetszerese;
        }
        static bool NegyvenOtvenKozt(int[] Tomb)
        {
           bool van = false;
           do
           {
                i++;
   	       } while (Tomb[i] >! 40 && Tomb[i] <! 50);
          
           return van;
        }
        static int TombRendezés(int[] Tomb)
            {
            int RendezettTomb= new int[10];
            int seged = Tomb[0];
            for (int i = 1; i < Tomb.Length; i++)
			{
                for (int j = 0; j < RendezettTomb.Length; j++)
			    {
                       
    			}
            }


        static void Main(string[] args)
        {
            int[] Tomb = RandomTombGenerator();

        }
    }
}
