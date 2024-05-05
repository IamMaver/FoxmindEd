using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Input;
using Task10.Core.Models;

namespace task10
{
    public partial class MainWindow : Window
    {

        private readonly Task10DBContext db = new ();
        public uint SelectedCourse { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.SeedDatabase();
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Courses.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Courses.Local.ToObservableCollection();
        }

        private void CoursesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedCourse = (Course)coursesList.SelectedItem;
            if (selectedCourse != null)
            {
                var groupWindow = new GroupWindow(selectedCourse);
                groupWindow.Show();
            }
        }
    }
}