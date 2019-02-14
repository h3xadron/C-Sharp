using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleNeptun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A neptunk objektum létrehozása előtt..");

            Neptun PeldanyaANeptunnak = new Neptun();

            Console.WriteLine("Létrejött a netpun");
            Console.ReadLine();
        }
    }
}
