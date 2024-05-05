using System.Windows;
using System.Windows.Controls;
using Task10.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace task10
{
    public partial class TeacherWindow : Window
    {
        private Teacher _selectedTeacher;
        private readonly Task10DBContext db = new();
        public TeacherWindow()
        {
            InitializeComponent();
            Loaded += TeacherWindow_Loaded;
        }
        private void TeacherWindow_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Task10DBContext())
            {
                db.Teachers.Load();
                DataContext = db.Teachers.Local.ToObservableCollection();
            }
        }
        private void TeacherEdit(object sender, RoutedEventArgs e)
        {
            if (_selectedTeacher != null)
            {
                string tName = Microsoft.VisualBasic.Interaction.InputBox("Please input new teacher's name:", "Edit teacher");
                string tSurName = Microsoft.VisualBasic.Interaction.InputBox("Please input new teacher's surname:", "Edit teacher");
                if (!tName.IsNullOrEmpty() && !tSurName.IsNullOrEmpty())
                {
                    TeacherEditService(tName, tSurName);
                }
                else
                {
                    MessageBox.Show("Name & Surname must be not empty");
                }
            }
            else
            {
                MessageBox.Show("Please select teacher");
            }
        }
        private void TeacherAdd(object sender, RoutedEventArgs e)
        {
            string tName = Microsoft.VisualBasic.Interaction.InputBox("Please input teacher's name:", "Add student");
            string tSurName = Microsoft.VisualBasic.Interaction.InputBox("Please input teacher's surname:", "Add student");
            if (!tName.IsNullOrEmpty() && !tSurName.IsNullOrEmpty())
            {
                TeacherAddService(tName, tSurName);
            }
            else
            {
                MessageBox.Show("Name & Surname must be not empty");
            }
        }
        private void TeacherDelete(object sender, RoutedEventArgs e)
        {
            if (_selectedTeacher != null)
            {
                TeacherDeleteService();
            }
            else
            {
                MessageBox.Show("Please select teacher");
            }
        }
        private void TeachersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            _selectedTeacher = (Teacher)listBox.SelectedItem;
        }
    }
}