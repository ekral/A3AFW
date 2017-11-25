using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformStudents
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
            set { _zapsany = value; OnPropertyChange(); }
        }

        public Student()
        {
           
        }
    }
}
