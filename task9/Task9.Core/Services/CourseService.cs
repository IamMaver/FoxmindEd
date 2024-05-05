using Microsoft.EntityFrameworkCore;
using task9.Models;

namespace Task9.Core.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> Get(int id);
        Task Add(Course course);
        Task Update(Course course);
        Task Delete(Course course);
    }

    public class CourseService : ICourseService
    {
        private readonly Task9DBContext _dbContext;

        public CourseService(Task9DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _dbContext.Courses.ToListAsync();
        }

        public async Task<Course> Get(int id)
        {
            return await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Add(Course course)
        {
            _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Course course)
        {
            _dbContext.Courses.Update(course);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Course course)
        {
            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();
        }
    }
}