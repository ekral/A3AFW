using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppBindingsAndTriggers
{
    public class Data : ViewModelBase
    {
        public ObservableCollection<Student> Studenti { get; set; }
        public RelayCommand CommandZapisZapocet { get; set; }

        public Data()
        {
            Studenti = new ObservableCollection<Student>()
            {
                new Student() { Jmeno="Prvni", MaZapocet=false},
                new Student() { Jmeno="Druhy", MaZapocet=true},
                new Student() { Jmeno="Treti", MaZapocet=false}
            };

            CommandZapisZapocet = new RelayCommand(ZapisZapocet, (parameter) => !MaZapocet(parameter));
        }

        private void ZapisZapocet(object parameter)
        {
            if(parameter != null && parameter is Student student)
            {
                student.MaZapocet = true;
            }
        }

        private bool MaZapocet(object parameter)
        {
            if (parameter != null && parameter is Student student)
            {
                return student.MaZapocet;
            }

            return false;
        }
    }
}
