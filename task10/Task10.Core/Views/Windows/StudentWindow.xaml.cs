using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Task10.Core.Models;

namespace task10
{
    public partial class StudentWindow : Window
    {
        private readonly Group _selectedGroup;
        private Student _selectedStudent;
        Task10DBContext db = new();
        public StudentWindow(Group selectedGroup)
        {
            _selectedGroup = selectedGroup;
            InitializeComponent();
            Loaded += StudentWindow_Loaded;
        }

        private void StudentWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.Students.Where(s => s.GroupId == _selectedGroup.Id).Load();
            DataContext = db.Students.Local.ToObservableCollection();
        }

        private void StudentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            _selectedStudent = (Student)listBox.SelectedItem;
        }
        private void StudentEdit(object sender, RoutedEventArgs e)
        {
            if (_selectedStudent != null)
            {
                string stName = Microsoft.VisualBasic.Interaction.InputBox("Please input new student's name:", "Edit student");
                string stSurName = Microsoft.VisualBasic.Interaction.InputBox("Please input new student's surname:", "Edit student");
                if (!stName.IsNullOrEmpty() && !stSurName.IsNullOrEmpty())
                {
                    _selectedStudent.Name = stName;
                    _selectedStudent.SurName = stSurName;
                    db.Students.Update(_selectedStudent);
                    db.SaveChanges();
                    var groupId = _selectedGroup.Id;
                    var updatedStudents = db.Students.Where(s => s.GroupId == groupId).ToList();
                    DataContext = new ObservableCollection<Student>(updatedStudents);
                }
                else
                {
                    MessageBox.Show("Name & Surname must be not empty");
                }
            }
            else
            {
                MessageBox.Show("Please select student");
            }
        }
        private void StudentAdd(object sender, RoutedEventArgs e)
        {
            string stName = Microsoft.VisualBasic.Interaction.InputBox("Please input student's name:", "Add student");
            string stSurName = Microsoft.VisualBasic.Interaction.InputBox("Please input student's surname:", "Add student");
            if (!stName.IsNullOrEmpty() && !stSurName.IsNullOrEmpty())
            {
                Student newStudent = new();
                newStudent.Name = stName;
                newStudent.SurName = stSurName;
                newStudent.GroupId = _selectedGroup.Id;
                db.Students.Add(newStudent);
                db.SaveChanges();
                var groupId = _selectedGroup.Id;
                var updatedStudents = db.Students.Where(s => s.GroupId == groupId).ToList();
                DataContext = new ObservableCollection<Student>(updatedStudents);
            }
            else
            {
                MessageBox.Show("Name & Surname must be not empty");
            }
        }
        private void StudentDelete(object sender, RoutedEventArgs e)
        {
            if (_selectedStudent != null)
            {
                db.Students.Remove(_selectedStudent);
                _selectedStudent = null;
                db.SaveChanges();
                var groupId = _selectedGroup.Id;
                var updatedStudents = db.Students.Where(s => s.GroupId == groupId).ToList();
                DataContext = new ObservableCollection<Student>(updatedStudents);
            }
            else
            {
                MessageBox.Show("Please select student");
            }
        }
    }
}