using System;
using System.Collections.Generic;
using System.Text;

namespace KempingFoglalas
{
    public class Foglalas
    {
        public string VendegNev { get; set; }
        public string ParcellaTipus { get; set; }
        public int EjszakakSzama { get; set; }
        public int FelnotFo { get; set; }
        public int GyerekFo { get; set; }


        public Foglalas(string sor)
        {
            var adatok = sor.Split(';');
            VendegNev = adatok[0];
            ParcellaTipus = adatok[1];
            EjszakakSzama = int.Parse(adatok[2]);
            FelnotFo = int.Parse(adatok[3]);
            GyerekFo = int.Parse(adatok[4]);
        }
        public int FizetendoOsszeg()
        {
            int osszeg = 0;
            if (ParcellaTipus == "ALAP")
            {
                osszeg = EjszakakSzama * 6000 + EjszakakSzama *  (FelnotFo * 500 + GyerekFo * 1500);
            }
            else if (ParcellaTipus == "KOMFORT")
            {
                osszeg = EjszakakSzama *  9500 + EjszakakSzama * (FelnotFo * 4000 + GyerekFo * 2500);
            }
            if (EjszakakSzama >=5)
            {
                osszeg = (int)(osszeg * 0.9);
            }
            return osszeg;
        }
        public override string ToString()
        {
            return $"{VendegNev} ({ParcellaTipus}): {EjszakakSzama} éjszaka, {FelnotFo} felnőtt, {GyerekFo} gyerek - Fizetendő: {FizetendoOsszeg()} Ft";
        }
    }
}
