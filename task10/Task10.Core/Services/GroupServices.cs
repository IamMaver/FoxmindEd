using iText.Kernel.Pdf;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task10.Core.Models;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace task10
{
    public partial class AddGroupWindow
    {
        void GroupCreateService()
        {
            Group newGroup = new();
            newGroup.Name = _newGroupName;
            newGroup.CourseId = _selectedCourseId;
            newGroup.TeacherId = _selectedTeacher.Id;
            _db.Groups.Add(newGroup);
            _db.SaveChanges();
        }
        void SetDataContextServ()
        {
            _db.Teachers.Load();
            DataContext = _db.Teachers.Local.ToObservableCollection();
        }
    }

    public partial class GroupWindow
    {
        void WritePDFService(string fileName)
        {
            PdfWriter writer = new(fileName);
            PdfDocument pdf = new(writer);
            iText.Layout.Document doc = new(pdf);
            iText.Layout.Element.Paragraph title = new("Course: " + _selectedCourse.NameCourse + " | Group: " + _selectedGroup.Name);
            doc.Add(title);
            _db.Students.Where(s => s.GroupId == _selectedGroup.Id).Load();
            for (int i = 0; i < _selectedGroup.Students.Count; i++)
            {
                var student = _selectedGroup.Students.ElementAt(i);
                iText.Layout.Element.Paragraph studentLine = new((i + 1) + ". " + student.Name + " " + student.SurName);
                doc.Add(studentLine);
            }
            doc.Close();
        }
        void WriteDOCXService(string fileName)
        {
            using (DocX doc = DocX.Create(fileName))
            {
                Xceed.Document.NET.Paragraph title = doc.InsertParagraph();
                title.Append("Course: " + _selectedCourse.NameCourse + " | Group: " + _selectedGroup.Name)
                    .Bold()
                    .FontSize(14)
                    .Alignment = Alignment.center;
                _db.Students.Where(s => s.GroupId == _selectedGroup.Id).Load();
                for (int i = 0; i < _selectedGroup.Students.Count; i++)
                {
                    var student = _selectedGroup.Students.ElementAt(i);
                    Xceed.Document.NET.Paragraph studentLine = doc.InsertParagraph();
                    studentLine.Append((i + 1) + ". " + student.Name + " " + student.SurName)
                        .Bold()
                        .FontSize(12);
                }
                doc.Save();
            }
        }
        void GroupImportService(string fileName)
        {
            using (var importContext = new Task10DBContext())
            {
                var group = importContext.Groups.Include(g => g.Students).SingleOrDefault(g => g.Id == _selectedGroup.Id);
                if (group != null)
                {
                    importContext.Students.RemoveRange(group.Students);
                    IEnumerable<string> lines = File.ReadLines(fileName);
                    foreach (string line in lines)
                    {
                        string[] slist = line.Split(',');
                        Student student = new();
                        student.Name = slist[0];
                        student.SurName = slist[1];
                        student.GroupId = group.Id;
                        importContext.Students.Add(student);
                    }
                    importContext.SaveChanges();
                }
            }
        }
    }
}