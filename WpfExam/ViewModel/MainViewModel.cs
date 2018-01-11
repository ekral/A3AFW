using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExam.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string _retezec;

        public string Retezec
        {
            get { return _retezec; }
            set { _retezec = value; Count(); OnPropertyChanged(); }
        }

        private string _znak;

        public string Znak
        {
            get { return _znak; }
            set { _znak = value; Count(); OnPropertyChanged(); }
        }

        private int _pocet;

        public int Pocet
        {
            get { return _pocet; }
            set { _pocet = value; OnPropertyChanged(); }
        }

        public RelayCommand CommandReset { get; set; }

        public MainViewModel()
        {
            CommandReset = new RelayCommand(Reset);
            Reset();
        }

        private void Reset()
        {
            Retezec = string.Empty;
            Znak = string.Empty;
            Pocet = 0;
        }

        private void Count()
        {
            int pocet = 0;

            if (!string.IsNullOrEmpty(Retezec) && !string.IsNullOrEmpty(Znak))
            {
                char znak = Znak.First();
                pocet = Retezec.Count(z => z == znak);
            }

            Pocet = pocet;
        }
    }
}
