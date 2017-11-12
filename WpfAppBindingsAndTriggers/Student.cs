using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppBindingsAndTriggers
{
    public class Student : ViewModelBase
    {
        private string _jmeno;

        public string Jmeno
        {
            get { return _jmeno; }
            set { _jmeno = value; OnPropertyChange(); }
        }


        private bool _maZapocet;
        public bool MaZapocet
        {
            get { return _maZapocet; }
            set { _maZapocet = value; OnPropertyChange(); }
        }

    }
}
