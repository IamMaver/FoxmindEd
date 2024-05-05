using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task10.Core.Models
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