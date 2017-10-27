using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppListOfNumbers
{
    public class Data
    {
        public ObservableCollection<int> Cisla { get; set; }

        public Data()
        {
            Cisla = new ObservableCollection<int>();
            Random rnd = new Random();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += (sender, e) => Cisla.Insert(0, rnd.Next() % 10);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
    }
}
