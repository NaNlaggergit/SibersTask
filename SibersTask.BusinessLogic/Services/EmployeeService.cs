using Microsoft.EntityFrameworkCore;
using SibersTask.Domain.Entities;
using SibersTask.Infrastructure.Data;
using System.Threading.Tasks;

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
        public async Task<List<Employee>> GetByIdsAsync(string ids)
        {
            var idList = ids.Split(',')
                .Select(int.Parse)
                .Distinct()
                .ToList();

            return await _db.Employees
                .Where(e => idList.Contains(e.Id))
                .Select(e => new Employee
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    MiddleName = e.MiddleName
                })
                .ToListAsync();
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
        public async Task<IEnumerable<Employee>> SearchAsync(string searchTerm)
        {
            return await _db.Employees
                .Where(e =>
                    e.LastName.Contains(searchTerm) ||
                    e.FirstName.Contains(searchTerm) ||
                    e.MiddleName.Contains(searchTerm))
                .Take(10) // Ограничиваем количество результатов для производительности
                .ToListAsync();
        }
    }
}
