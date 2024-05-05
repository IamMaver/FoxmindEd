using Microsoft.EntityFrameworkCore;
using task9.Models;

namespace Task9.Core.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> Get(int id);
        Task<IEnumerable<Student>> GetStudentsByGroupId(int groupId);
        Task Add(Student group);
        Task Update(Student group);
        Task Delete(Student group);
    }

    public class StudentService : IStudentService
    {
        private readonly Task9DBContext _dbContext;

        public StudentService(Task9DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> Get(int id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudentsByGroupId(int groupId)
        {
            return await _dbContext.Students.Where(s => s.GroupId == groupId).ToListAsync();
        }

        public async Task Add(Student student)
        {
            _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Student student)
        {
            _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
            if (student == null)
            {
                return;
            }
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
        }
    }
}