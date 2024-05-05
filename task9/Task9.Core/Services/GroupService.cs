using Microsoft.EntityFrameworkCore;
using task9.Models;

namespace Task9.Core.Services
{

    public interface IGroupService
    {

        Task<IEnumerable<Group>> GetAll();
        Task<IEnumerable<Group>> GetAll4Course(int courseId);
        Task<Group> Get(int id);
        Task Add(Group group);
        Task Update(Group group);
        Task Delete(Group group);
    }

    public class GroupService : IGroupService
    {
        private readonly Task9DBContext _dbContext;

        public GroupService(Task9DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            return await _dbContext.Groups.ToListAsync();
        }

        public async Task<IEnumerable<Group>> GetAll4Course(int courseId)
        {
            return await _dbContext.Groups.Where(g => g.CourseId == courseId).ToListAsync();
        }

        public async Task<Group> Get(int id)
        {
            return await _dbContext.Groups.Include(g => g.Students).FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task Add(Group group)
        {
            _dbContext.Groups.AddAsync(group);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Group group)
        {
            _dbContext.Groups.Update(group);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Group group)
        {
            if (group != null)
            {
                if (group.Students.Count > 0)
                {
                    return;
                }
                _dbContext.Groups.Remove(group);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}