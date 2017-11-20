using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpAppStudentsXBind
{
    public class Student : ViewModelBase
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }

        private bool _zapsany;
        
        public bool JeZapsany
        {
            get { return _zapsany; }
            set { _zapsany = value; OnPropertyChange(nameof(JeZapsany));  }
        }

        public Student()
        {
        }

        public void Zapis(object sender, RoutedEventArgs e)
        {
            JeZapsany = true;
        }
    }
}
