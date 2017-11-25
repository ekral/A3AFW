using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UwpAppStudentsXBind
{
    public class Data
    {
        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set { _selectedStudent = value; }
        }

        public ObservableCollection<Student> Studenti { get; set; }

        public Data()
        {
            Studenti = new ObservableCollection<Student>()
            {

                new Student() { Id = 1, Jmeno = "Erik", Prijmeni = "Kral", JeZapsany = true},
                new Student() { Id = 2, Jmeno = "Petr", Prijmeni = "Capek", JeZapsany = false},
                new Student() { Id = 3, Jmeno = "Karel", Prijmeni = "Novy", JeZapsany = false}
            };
        }

        private void OdstranStudenta(object parameter)
        {
            if((parameter != null) && (parameter is Student student) && (Studenti.Contains(student)))
            {
                Studenti.Remove(student);
            }
        }
    }
}
