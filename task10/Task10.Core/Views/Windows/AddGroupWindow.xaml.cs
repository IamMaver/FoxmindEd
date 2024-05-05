using System.Windows;
using System.Windows.Controls;
using Task10.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace task10
{
        public partial class AddGroupWindow : Window
    {
        private Teacher _selectedTeacher;
        private readonly int _selectedCourseId;
        private string _newGroupName;
        private readonly Task10DBContext _db = new();
        public AddGroupWindow(int courseId)
        {
            _selectedCourseId = courseId;
            InitializeComponent();
            Loaded += AddGroupWindow_Loaded;
        }

        private void AddGroupWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SetDataContextServ();
        }

        private void AddGroupsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            _selectedTeacher = (Teacher)listBox.SelectedItem;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _newGroupName = textBox.Text;
        }
        private void GroupCreate(object sender, RoutedEventArgs e)
        {
            if (_selectedTeacher != null && !_newGroupName.IsNullOrEmpty())
            {
                GroupCreateService();
                Window.GetWindow(this)?.Close();
            }
        }
    }
}