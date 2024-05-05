using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Task10.Core.Models;
using Microsoft.IdentityModel.Tokens;


namespace task10
{
    public partial class EditGroupWindow : Window
    {
        private Teacher _selectedTeacher;
        private Group _group;
        private string _newGroupName;
        public Teacher SelectedTeacher { get; set; }
        private readonly Task10DBContext _db = new();
        public EditGroupWindow(Group group)
        {
            _group = group;
            InitializeComponent();
            Loaded += EditGroupWindow_Loaded;
        }

        private void EditGroupWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _db.Teachers.Load();
            if (_group != null)
            {
                groupNameTextBox.Text = _group.Name;
            }
            DataContext = _db.Teachers.Local.ToObservableCollection();
        }
        private void GroupEdit(object sender, RoutedEventArgs e)
        {

            if (_selectedTeacher == null)
            {
                MessageBox.Show("Please select teacher");
                return;
            }
            if (!_newGroupName.IsNullOrEmpty())
            {
                _group.Name = _newGroupName;
            }
            _group.TeacherId = _selectedTeacher.Id;
            _db.Groups.Update(_group);
            _db.SaveChanges();
            Window.GetWindow(this)?.Close();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _newGroupName = (string)textBox.Text;
        }
        private void EditGroupsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            _selectedTeacher = (Teacher)listBox.SelectedItem;
        }
    }
}
