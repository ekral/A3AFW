using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformStudents
{
    public class Data : ViewModelBase
    {
        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set { _selectedStudent = value; OnPropertyChange(); }
        }

        public ObservableCollection<Student> Studenti { get; set; }

        public RelayCommand CommandZapisStudenta { get; set; }
        public RelayCommand CommandOdstranStudenta { get; set; }
        public RelayCommand CommandOdstranSelectedStudenta { get; set; }
        

        public Data()
        {
            Studenti = new ObservableCollection<Student>()
            {
                new Student() { Id = 1, Jmeno = "Erik", Prijmeni = "Kral", JeZapsany = false},
                new Student() { Id = 2, Jmeno = "Petr", Prijmeni = "Capek", JeZapsany = false},
                new Student() { Id = 2, Jmeno = "Dalsi", Prijmeni = "Student", JeZapsany = false},
                new Student() { Id = 3, Jmeno = "Karel", Prijmeni = "Novy", JeZapsany = false}
            };

            CommandZapisStudenta = new RelayCommand(ZapisStudenta, MuzuZapsatStudenta);
            CommandOdstranStudenta = new RelayCommand(OdstranStudenta, MuzuOdstranitStudenta);
            CommandOdstranSelectedStudenta = new RelayCommand(OdstranSelectedStudenta, null);

            SelectedStudent = Studenti.First();

        }

        private void ZapisStudenta(object parameter)
        {
            if ((parameter != null) && (parameter is Student student) && (Studenti.Contains(student)))
            {
                student.JeZapsany = true;

                CommandZapisStudenta.RaiseCanExecuteChanged();
                CommandOdstranStudenta.RaiseCanExecuteChanged();
            }
        }
        private void OdstranStudenta(object parameter)
        {
            if ((parameter != null) && (parameter is Student student) && (Studenti.Contains(student)))
            {
                Studenti.Remove(student);
                SelectedStudent = Studenti.Count > 0 ? Studenti.First() : null;
            }
        }

        private void OdstranSelectedStudenta(object parameter)
        {
            if (SelectedStudent != null)
            {
                Studenti.Remove(SelectedStudent);
                SelectedStudent = Studenti.Count > 0 ? Studenti.First() : null;
            }
        }

        private bool MuzuZapsatStudenta(object parameter)
        {
            if ((parameter != null) && (parameter is Student student) && (Studenti.Contains(student)))
            {
                return !student.JeZapsany;
            }

            return false;
        }

        private bool MuzuOdstranitStudenta(object parameter)
        {
            // studenta muzu odstranit jen kdyz neni zapsany, tedy muzu ho zapsat
            return MuzuZapsatStudenta(parameter);
        }

    }
}
