using Microsoft.EntityFrameworkCore;
using SibersTask.Domain.Entities;
using SibersTask.Infrastructure.Data;

namespace SibersTask.BusinessLogic.Services
{
    public class EmployeeService
    {
        private readonly AppDbContext _db;

        public EmployeeService(AppDbContext db) => _db = db;

        public async Task<Employee> CreateAsync(Employee entity)
        {
            _db.Employees.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee?> GetByIdAsync(int id)
            => await _db.Employees.FindAsync(id);

        public async Task<IEnumerable<Employee>> GetAllAsync()
            => await _db.Employees.ToListAsync();

        public async Task<bool> UpdateAsync(Employee entity)
        {
            if (!await _db.Employees.AnyAsync(x => x.Id == entity.Id)) return false;
            _db.Employees.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Employees.FindAsync(id);
            if (entity == null) return false;
            _db.Employees.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
