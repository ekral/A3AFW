using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppStudentDeleteTemplate
{
    public class Student : ViewModelBase
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        private bool _jeZapsany;

        public RelayCommand CommandZapis { get; set; }
        public bool JeZapsany
        {
            get { return _jeZapsany; }
            set { _jeZapsany = value; OnPropertyChange(); }
        }

        public Student()
        {
            CommandZapis = new RelayCommand(p => JeZapsany = true, () => !JeZapsany);
        }
    }
}
