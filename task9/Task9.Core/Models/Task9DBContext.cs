using Microsoft.EntityFrameworkCore;

namespace task9.Models
{
    public class Task9DBContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

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
            using (var context = new Task9DBContext())
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

                    var student1 = new Student { Name = "Ivan Ivanov", Group = group1 };
                    var student2 = new Student { Name = "Dmytro Dmitriev", Group = group1 };
                    var student3 = new Student { Name = "Mykola Nikolaev", Group = group1 };
                    var student4 = new Student { Name = "Yaroslav Yaroslavlev", Group = group2 };
                    var student5 = new Student { Name = "Zlata Zolotareva", Group = group3 };
                    var student6 = new Student { Name = "Petr Petrov", Group = group4 };


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

                    context.SaveChanges();
                }
            }
        }
    }
}