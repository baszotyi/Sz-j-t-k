using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szójáték
{
    internal class Szojatek
    {
        public string fájl;
        List<string> szavak = new List<string>();
        
        public Szojatek(string fájl) 
        {
            this.fájl = fájl;
            Beolvas();
        }

        internal void LeghosszabbSzo()
        {
            string leghosszabbSzo = string.Empty;
            int maxHosszusag = 0;

            foreach (var szó in szavak)
            {      
                if (szó.Length > maxHosszusag)
                {
                    leghosszabbSzo = szó;
                    maxHosszusag = szó.Length;
                }
            }
            if (maxHosszusag > 0)
            {
                Console.WriteLine("A leghosszabb szó: {0}, hossza: {1} karakter.", leghosszabbSzo, maxHosszusag);
            }
        }

        internal void TartalmazEMaganhangzot(string bekertszo)
        {
            if (bekertszo.Contains('a') || bekertszo.Contains('e') || bekertszo.Contains('i') || bekertszo.Contains('o') || bekertszo.Contains('u'))
                {
                Console.WriteLine("Van benne magánhangzó. ");
            }
            else
            {
                Console.WriteLine("Nincs benne magánhangzó.");
            }
        }

        private void Beolvas()
        {
            string[] sorok = File.ReadAllLines(fájl);
            for (int i = 0; i < sorok.Length; i++)
            {
                string szó = sorok[i];
                szavak.Add(szó);
            }
        }
    }
}
