using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppStudentDeleteTemplate
{
    public class Data
    {
        public ObservableCollection<Student> Studenti { get; set; }
        public RelayCommand CommandDelete { get; set; }
        public Data()
        {
            Studenti = new ObservableCollection<Student>()
            {
                new Student() { Id = 1, Jmeno = "Jiri", JeZapsany = true},
                new Student() { Id = 2, Jmeno = "Petra", JeZapsany = false},
                new Student() { Id = 3, Jmeno = "Karel", JeZapsany = false}
            };

            CommandDelete = new RelayCommand(SmazStudenta, null);
        }

        private void SmazStudenta(object parameter)
        {
            if(parameter is Student student)
            {
                Studenti.Remove(student);
            }
        }
    }
}
