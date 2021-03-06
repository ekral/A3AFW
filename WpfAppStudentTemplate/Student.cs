﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppStudentTemplate
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
            set { _zapsany = value; OnPropertyChange(nameof(JeZapsany)); }
        }


        public RelayCommand CommandZapis { get; set; }

        public Student()
        {
            CommandZapis = new RelayCommand(Zapis, null);
        }

        public void Zapis(object parameter)
        {
            JeZapsany = true;
        }
    }
}
