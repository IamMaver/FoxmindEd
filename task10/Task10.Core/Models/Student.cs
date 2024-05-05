using System.ComponentModel.DataAnnotations;

namespace Task10.Core.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}