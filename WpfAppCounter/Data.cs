using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCounter
{
    class Data : INotifyPropertyChanged 
    {
        private int maximum;

        public int Maximum
        {
            get { return maximum; }
            set { maximum = value; OnPropertyChange(nameof(Maximum)); }
        }

        private int pocitadlo;
        public int Pocitadlo
        {
            get { return pocitadlo; }
            set { pocitadlo = value; OnPropertyChange(nameof(Pocitadlo)); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public RelayCommand CommandZmena { get; set; }
        public RelayCommand CommandReset { get; set; }

        public Data()
        {
            Maximum = 10;
            Pocitadlo = 0;
            CommandZmena = new RelayCommand(Zmen, MuzeZmenit);
            CommandReset = new RelayCommand(Reset, null);

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += (sender, e) => { ++Pocitadlo; CommandZmena.OnCanExecuteChanged(); };
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void Reset(object param)
        {
            Pocitadlo = 0;
        }

        private bool MuzeZmenit()
        {
            return Pocitadlo < Maximum;
        }

        private void Zmen(object param)
        {
            if (param is string retezec)
            {
                if (int.TryParse(retezec, out int cislo))
                {
                    Pocitadlo += cislo;
                }
            }
        }
    }
}
