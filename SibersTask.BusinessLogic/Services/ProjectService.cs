using SibersTask.Domain.Entities;
using SibersTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SibersTask.BusinessLogic.Services
{
    public class ProjectService
    {
        private readonly AppDbContext _db;
        public ProjectService(AppDbContext db) => _db = db;
        public async Task<Project> CreateAsync(Project entity)
        {
            _db.Projects.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Project?> GetByIdAsync(int id)
            => await _db.Projects.FindAsync(id);

        public async Task<IEnumerable<Project>> GetAllAsync()
            => await _db.Projects.ToListAsync();

        public async Task<bool> UpdateAsync(Project entity)
        {
            if (!await _db.Projects.AnyAsync(x => x.Id == entity.Id)) return false;
            _db.Projects.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Projects.FindAsync(id);
            if (entity == null) return false;
            _db.Projects.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
