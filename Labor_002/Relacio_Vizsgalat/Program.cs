using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relacio_Vizsgalat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérlek adj meg két számot!");
            int ElsoSzam = int.Parse(Console.ReadLine());
            int MasodikSzam = int.Parse(Console.ReadLine());

            if (ElsoSzam > MasodikSzam)
            {
                Console.WriteLine(ElsoSzam + ">" + MasodikSzam);
            }
            else if (ElsoSzam < MasodikSzam)
            {
                Console.WriteLine(ElsoSzam + "<" + MasodikSzam);
            }
            else
            {
                Console.WriteLine(ElsoSzam + "=" + MasodikSzam);
            }
            Console.Read();

            
        }
    }
}
