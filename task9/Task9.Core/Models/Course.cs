using System.ComponentModel.DataAnnotations;

namespace task9.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string NameCourse { get; set; }
        public string Description { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}