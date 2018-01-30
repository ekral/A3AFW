using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformNavigation
{
    class KalendarViewModel : ViewModelBase
    {
        public string Test { get; set; } = "ahoj";

        private List<KalendarItem> _kalendar;
        
        public List<KalendarItem> Kalendar
        {
            get { return _kalendar; }
            set { _kalendar = value; OnPropertyChange(); }
        }

        // jen pro ukazku, tlacitko zpet je v menu
        public RelayCommand CommandZpet { get; private set; }

        private readonly Xamarin.Forms.INavigation navigation;

        public KalendarViewModel(Xamarin.Forms.INavigation navigation, double dluh, double rocniUrok, int pocetLet, DateTime zacatek)
        {
            this.navigation = navigation;
            CommandZpet = new RelayCommand(async parameter => await NavigateZpet(parameter));

            List<KalendarItem> kalendar = new List<KalendarItem>();

            int pocetMesicu = pocetLet * 12; // pocet mesicu splaceni
            double mesicniSazba = rocniUrok / (12 * 100); // desetinne cislo
            double v = 1 / (1 + mesicniSazba);
            double splatka = (mesicniSazba * dluh) / (1 - Math.Pow(v, pocetMesicu));

            for (int i = 0; i < pocetMesicu; i++)
            {
                double urok = mesicniSazba * dluh;
                double umor = splatka - urok;

                dluh -= umor;

                zacatek = zacatek.AddMonths(1);
                kalendar.Add(new KalendarItem(zacatek, splatka, urok, umor, dluh));
                
            }

            Kalendar = kalendar;
            
        }

        async Task NavigateZpet(object parameter)
        {
            await navigation.PopAsync();
        }
    }
}
