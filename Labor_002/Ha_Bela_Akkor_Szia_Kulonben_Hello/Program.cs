using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ha_Bela_Akkor_Szia_Kulonben_Hello
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Mi a neved?");
            string Name = Console.ReadLine();
            if (Name == "Béla")
            {
                Console.WriteLine("Szia Béla!");
            }
            else
            {
                Console.WriteLine("Hello " + Name);
            }
            Console.ReadLine();
        }
    }
}
