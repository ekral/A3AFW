using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppStudents
{
    public class Data : ViewModelBase
    {

        public ObservableCollection<Student> Studenti { get; set; }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                JmenoEdit = SelectedStudent.Jmeno;
                OnPropertyChange("SelectedStudent");
            }
        }

        private string _jmenoEdit;

        public string JmenoEdit
        {
            get { return _jmenoEdit; }
            set { _jmenoEdit = value; OnPropertyChange("JmenoEdit"); }
        }

        private string _jmenoNove;

        public string JmenoNove
        {
            get { return _jmenoNove; }
            set { _jmenoNove = value; OnPropertyChange("JmenoNove"); }
        }

        public RelayCommand CommandJmenoEdit { get; set; }
        public RelayCommand CommandNovyStudent { get; set; }

        public Data()
        {
            Studenti = new ObservableCollection<Student>()
            {
                new Student(1, "Martin"),
                new Student(2, "Tomáš Peter"),
                new Student(3, "Roman"),
                new Student(4, "Petr"),
                new Student(5, "Adam"),
                new Student(6, "Jiří")
            };

            SelectedStudent = Studenti.First();

            CommandJmenoEdit = new RelayCommand(OnJmenoEdit);
            CommandNovyStudent = new RelayCommand(OnNovyStudent);
        }

        private void OnJmenoEdit()
        {
            SelectedStudent.Jmeno = JmenoEdit;
        }

        private void OnNovyStudent()
        {
            int idNove = Studenti.Max(o => o.Id) + 1;
            Student novyStudent = new Student(idNove, JmenoNove);
            Studenti.Add(novyStudent);
            SelectedStudent = novyStudent;
        }
    }
}
