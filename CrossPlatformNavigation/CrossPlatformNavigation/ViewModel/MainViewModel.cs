
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformNavigation
{
    public class MainViewModel : ViewModelBase
    {
        private double _urok;

        public double Urok
        {
            get { return _urok; }
            set { _urok = value; PrepocitejSplatku(); }
        }

        private double _dluh;

        public double Dluh
        {
            get { return _dluh; }
            set { _dluh = value; PrepocitejSplatku(); }
        }

        private int _pocetLet;

        public int PocetLet
        {
            get { return _pocetLet; }
            set { _pocetLet = value; PrepocitejSplatku(); }
        }

        private double _slatka;
        

        public double Splatka
        {
            get { return _slatka; }
            set { _slatka = value; OnPropertyChange(); }
        }

        public DateTime Datum { get; set; }

        public RelayCommand CommandKalendar { get; private set; }

        private readonly Xamarin.Forms.INavigation navigation;

        // navigation bychom meli dat do samostatne tridy a pouzit techniku DI
        public MainViewModel(Xamarin.Forms.INavigation navigation)
        {
            Dluh = 1000000;
            PocetLet = 20;
            Urok = 2;
            Datum = DateTime.Now;
            CommandKalendar = new RelayCommand(async parameter => await NavigateKalendar(parameter));
            this.navigation = navigation;
        }

        private void PrepocitejSplatku()
        {
            int n = PocetLet * 12; // pocet mesicu splaceni
            double i = Urok / (12 * 100); // desetinne cislo

            double v = 1 / (1 + i);
            double splatka = (i * Dluh) / (1 - Math.Pow(v, n));

            Splatka = splatka;
        }

        async Task NavigateKalendar(object parameter)
        {
            // Toto bychom meli zjednodusit s vyuzitim ioc a umoznit tak lepsi testovatelnost kodu (vymenili bychom napriklad viewModel za jiny testovaci)
            KalendarView view = new KalendarView();
            KalendarViewModel viewModel = new KalendarViewModel(view.Navigation, Dluh, Urok, PocetLet, Datum);
            view.BindingContext = viewModel;

            await navigation.PushAsync(view);
        }
    }
}
