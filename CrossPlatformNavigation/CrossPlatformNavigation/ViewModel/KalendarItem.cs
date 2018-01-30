using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPlatformNavigation
{
    class KalendarItem
    {
        public DateTime Cislo { get; }
        public double Splatka { get; }
        public double Urok { get; }
        public double Umor { get; }
        public double Dluh { get; }

        public KalendarItem(DateTime cislo, double splatka, double urok, double umor, double dluh)
        {
            Cislo = cislo;
            Splatka = splatka;
            Urok = urok;
            Umor = umor;
            Dluh = dluh;
        }


    }
}
