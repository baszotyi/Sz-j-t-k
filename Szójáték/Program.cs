using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szójáték
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string fájl = "szoveg.txt";
            Szojatek sz = new Szojatek(fájl);

            Console.WriteLine("1. Feladat");
            Console.Write("Írj be egy szót: ");
            string bekertszo = Console.ReadLine();
            sz.TartalmazEMaganhangzot(bekertszo);

            Console.WriteLine("\n2. Feladat");
            sz.LeghosszabbSzo();

            Console.WriteLine("\n3. Feladat");






            Console.ReadLine();
        }
    }
}
