using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task10.Core.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public ICollection <Group> Group { get; set; }
    }
}