using System.Linq;
using Task10.Core.Models;
using System.Collections.ObjectModel;
namespace task10
{
    public partial class TeacherWindow
    {
        void TeacherEditService(string tName, string tSurName)
        {
            _selectedTeacher.Name = tName;
            _selectedTeacher.SurName = tSurName;
            db.Teachers.Update(_selectedTeacher);
            db.SaveChanges();
            var updatedTeachers = db.Teachers.ToList();
            DataContext = new ObservableCollection<Teacher>(updatedTeachers);
        }
        void TeacherAddService(string tName, string tSurName)
        {
            Teacher newTeacher = new();
            newTeacher.Name = tName;
            newTeacher.SurName = tSurName;
            db.Teachers.Add(newTeacher);
            db.SaveChanges();
            var updatedTeachers = db.Teachers.ToList();
            DataContext = new ObservableCollection<Teacher>(updatedTeachers);
        }
        void TeacherDeleteService()
        {
            db.Teachers.Remove(_selectedTeacher);
            _selectedTeacher = null;
            db.SaveChanges();
            var updatedTeachers = db.Teachers.ToList();
            DataContext = new ObservableCollection<Teacher>(updatedTeachers);
        }
    }
}