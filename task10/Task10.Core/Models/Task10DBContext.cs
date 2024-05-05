using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task10.Core.Models
{
    public class Task10DBContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public void SeedDatabase()
        {
            using (var context = new Task10DBContext())
            {
                context.Database.EnsureCreated();

                if (!context.Courses.Any())
                {
                    var course1 = new Course { NameCourse = "IT", Description = "IT-Course" };
                    var course2 = new Course { NameCourse = "SR", Description = "Social responsibility" };

                    var group1 = new Group { Name = "IT-01", Course = course1 };
                    var group2 = new Group { Name = "IT-02", Course = course1 };
                    var group3 = new Group { Name = "SR-01", Course = course2 };
                    var group4 = new Group { Name = "SR-02", Course = course2 };

                    var student1 = new Student { Name = "Ivan", SurName = "Ivanov", Group = group1 };
                    var student2 = new Student { Name = "Dmytro", SurName = "Dmitriev", Group = group1 };
                    var student3 = new Student { Name = "Mykola", SurName = "Nikolaev", Group = group1 };
                    var student4 = new Student { Name = "Yaroslav", SurName = "Yaroslavlev", Group = group2 };
                    var student5 = new Student { Name = "Zlata", SurName = "Zolotareva", Group = group3 };
                    var student6 = new Student { Name = "Petr", SurName = "Petrov", Group = group4 };

                    var teacher1 = new Teacher { Name = "First", SurName = "Teacher1", Group = new List<Group> { group1 } };
                    var teacher2 = new Teacher { Name = "Second", SurName = "Teacher2", Group = new List<Group> { group2 } };
                    var teacher3 = new Teacher { Name = "Third", SurName = "Teacher3", Group = new List<Group> { group3 } };
                    var teacher4 = new Teacher { Name = "Fourth", SurName = "Teacher4", Group = new List<Group> { group4 } };

                    context.Courses.Add(course1);
                    context.Courses.Add(course2);
                    context.Groups.Add(group1);
                    context.Groups.Add(group2);
                    context.Groups.Add(group3);
                    context.Groups.Add(group4);

                    context.Students.Add(student1);
                    context.Students.Add(student2);
                    context.Students.Add(student3);
                    context.Students.Add(student4);
                    context.Students.Add(student5);
                    context.Students.Add(student6);

                    context.Teachers.Add(teacher1);
                    context.Teachers.Add(teacher2);
                    context.Teachers.Add(teacher3);
                    context.Teachers.Add(teacher4);

                    context.SaveChanges();
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasIndex(g => g.TeacherId)
                .IsUnique(false);
        }
    }
}