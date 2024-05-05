using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace Task10.Core.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int TeacherId { get; set; }
 
        public Teacher Teacher { get; set; }

        [InverseProperty("Group")]
        public ICollection<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }
    }
}