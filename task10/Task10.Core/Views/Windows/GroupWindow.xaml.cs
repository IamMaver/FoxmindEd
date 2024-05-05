using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Task10.Core.Models;
using System.Data;
using Microsoft.IdentityModel.Tokens;

namespace task10
{
    public partial class GroupWindow : Window
    {
        private readonly Course _selectedCourse;
        private Group _selectedGroup;
        private readonly Teacher _selectedTeacher;
        private readonly Task10DBContext _db = new();

        public GroupWindow(Course selectedCourse)
        {
            if (selectedCourse != null) _selectedCourse = selectedCourse;
            InitializeComponent();
            Loaded += GroupWindow_Loaded;
        }
        private void GroupWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _db.Groups.Where(g => g.CourseId == _selectedCourse.Id).Load();
            DataContext = _db.Groups.Local.ToObservableCollection();
        }
        private void GroupsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _selectedGroup = (Group)groupsList.SelectedItem;
            if (_selectedGroup != null)
            {
                var studentWindow = new StudentWindow(_selectedGroup);
                studentWindow.Show();
            }
        }
        private void GroupsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            _selectedGroup = (Group)listBox.SelectedItem;
        }
        private void GroupCreate(object sender, RoutedEventArgs e)
        {
            AddGroupWindow addGroupWindow = new((int)_selectedCourse.Id);
            addGroupWindow.ShowDialog();
            var courseId = _selectedCourse.Id;
            var updatedGroups = _db.Groups.Where(g => g.CourseId == courseId).ToList();
            DataContext = new ObservableCollection<Group>(updatedGroups);
        }
        private void GroupDelete(object sender, RoutedEventArgs e)
        {
            _db.Groups.Include(g => g.Students).Load();
            if (_selectedGroup == null)
            {
                return;
            }
            if (_selectedGroup.Students.Count > 0)
            {
                var courseId = _selectedCourse.Id;
                var updatedGroups = _db.Groups.Where(g => g.CourseId == courseId).ToList();
                DataContext = new ObservableCollection<Group>(updatedGroups);
                MessageBox.Show("Сan't delete non-empty group");
            }
            else
            {
                _db.Groups.Remove(_selectedGroup);
                _db.SaveChanges();
                var courseId = _selectedCourse.Id;
                var updatedGroups = _db.Groups.Where(g => g.CourseId == courseId).ToList();
                DataContext = new ObservableCollection<Group>(updatedGroups);
            }
        }

        private void GroupEdit(object sender, RoutedEventArgs e)
        {
            if (_selectedGroup == null)
            {
                MessageBox.Show("Please select group");
                return;
            }
            EditGroupWindow editGroupWindow = new(_selectedGroup);
            editGroupWindow.ShowDialog();
            var courseId = _selectedCourse.Id;
            var updatedGroups = _db.Groups.Where(g => g.CourseId == courseId).ToList();
            DataContext = new ObservableCollection<Group>(updatedGroups);
        }
        private void TeachersButton_Click(object sender, RoutedEventArgs e)
        {
            TeacherWindow teacherWindow = new();
            teacherWindow.ShowDialog();
        }
        private void GroupImport(object sender, RoutedEventArgs e)
        {
            if (_selectedGroup == null)
            {
                MessageBox.Show("Please select group");
            }
            else
            {
                string fileName = GetFileNameFromDialog();

                if (string.IsNullOrEmpty(fileName))
                {
                    return;
                }
                GroupImportService(fileName);
            }
        }

        private void GroupExportPDF(object sender, RoutedEventArgs e)
        {
            if (_selectedGroup == null)
            {
                MessageBox.Show("Please select group");
            }
            else
            {
                string fileName = GetFileNameFromDialogSaveAs("pdf files|*.pdf");
                if (fileName.IsNullOrEmpty())
                {
                    return;
                }
                WritePDFService(fileName);
            }
        }

        private static string GetFileNameFromDialog()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Cursor Files|*.csv";
            dialog.Title = "Select list of student in the format .csv";
            dialog.ShowDialog();
            return dialog.FileName;
        }
        private static string GetFileNameFromDialogSaveAs(string filter)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = filter;
            dialog.FilterIndex = 2;
            dialog.ShowDialog();
            return dialog.FileName;
        }

        private void GroupExportDOCX(object sender, RoutedEventArgs e)
        {
            if (_selectedGroup == null)
            {
                MessageBox.Show("Please select group");
            }
            else
            {
                string fileName = GetFileNameFromDialogSaveAs("docx files|*.docx");
                WriteDOCXService(fileName);
            }
        }
    }
}