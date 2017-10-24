using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppStudents
{
    public class Student : ViewModelBase
    {
        private string _jmeno;
        public string Jmeno
        {
            get { return _jmeno; }
            set { _jmeno = value; OnPropertyChange("Jmeno"); }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChange("Id"); }
        }

        public Student(int id, string jmeno)
        {
            Id = id;
            Jmeno = jmeno;
        }

        public override string ToString()
        {
            return $"{Id} {Jmeno}";

        }
    }
}
