using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

        internal void Szoletra(string bekertszo2)
        {
            // Ellenőrizzük, hogy a szórészlet 3 karakter hosszú-e
            List<string> otkarakteresSzavak = new List<string>();
         

            foreach (var szo in szavak)
            {
                if (szo.Length == 5)
                {
                    otkarakteresSzavak.Add(szo);
                }
            }
            // Szavak szűrése a megadott szórészlet alapján
            List<string> talaltSzavak = otkarakteresSzavak
                .Where(szo => szo.Contains(szo))
                .ToList();

            // Talált szavak kiírása
            Console.WriteLine(string.Join(" ", talaltSzavak));



            //Console.WriteLine("A megadott szórészlet nem 3 karakter hosszú.");


        }

        internal void TaroltSzavakFeladat()
        {
            // Szavak csoportosítása
            var letrak = new Dictionary<string, List<string>>();

            foreach (var szo in szavak)
            {
                if (szo.Length == 5)
                {
                    // Az első és utolsó karakter levágása
                    string kulcs = szo.Substring(1, 3);
                    if (!letrak.ContainsKey(kulcs))
                    {
                        letrak[kulcs] = new List<string>();
                    }
                    letrak[kulcs].Add(szo);
                }
            }

            // Eredmények írása a letra.txt fájlba
            using (StreamWriter writer = new StreamWriter("letra.txt "))
            {
                foreach (var par in letrak)
                {
                    // Csak akkor írjuk ki, ha van legalább 2 szó
                    if (par.Value.Count > 1)
                    {
                        foreach (var szo in par.Value)
                        {
                            writer.WriteLine(szo);
                        }
                        writer.WriteLine(); // Üres sor a létrák között
                    }
                }
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

        internal void TobbMagaanHangzo()
        {
            List<string> talaltSzavak = new List<string>();
            int osszesSzo = szavak.Count;

            foreach (var szo in szavak)
            {
                int maganhangzokSzama = szo.Count(c => "aeiouáéíóöőúü".Contains(c));
                int massalhangzokSzama = szo.Length - maganhangzokSzama;

                if (maganhangzokSzama > massalhangzokSzama)
                {
                    talaltSzavak.Add(szo);
                }
            }

            // Talált szavak kiírása
            Console.WriteLine(string.Join(" ", talaltSzavak));

            // Statisztikák kiírása
            int talaltSzavakSzama = talaltSzavak.Count;
            double szazalek = (osszesSzo > 0) ? (double)talaltSzavakSzama / osszesSzo * 100 : 0;

            Console.WriteLine($"Talált szavak száma: {talaltSzavakSzama}");
            Console.WriteLine($"Összes szó száma: {osszesSzo}");
            Console.WriteLine($"A talált szavak aránya: {szazalek:F2}%");
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
