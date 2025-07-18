using SibersTask.Domain.Entities;
using SibersTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace SibersTask.BusinessLogic.Services
{
    public class ProjectService
    {
        private readonly AppDbContext _db;
        public ProjectService(AppDbContext db) => _db = db;
        public async Task<Project> CreateAsync(dynamic entity)
        {
            JsonElement jsonElement = entity;
            var project= new Project
            {
                Name = jsonElement.GetProperty("name").GetString(),
                StartDate = jsonElement.GetProperty("startDate").GetDateTime(),
                EndDate = jsonElement.GetProperty("endDate").GetDateTime(),
                ContractorCompany = jsonElement.GetProperty("customerCompany").GetString(),
                CustomerCompany = jsonElement.GetProperty("executorCompany").GetString(),
                ManagerId = jsonElement.GetProperty("managerId").GetInt32(),
                Priority= jsonElement.GetProperty("priority").GetInt32()
            };
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();
            List<int> employeeIds = jsonElement
                .GetProperty("employeeIds")
                .EnumerateArray()
                .Select(x => x.GetInt32())
                .ToList();
            foreach (var employeeId in employeeIds)
            {
                var projectEmployee = new ProjectEmployee
                {
                    ProjectId = project.Id,
                    EmployeeId = employeeId
                };
                _db.ProjectEmployees.Add(projectEmployee);
            }
            await _db.SaveChangesAsync();
            return project;
        }
        public async Task<Project?> GetByIdAsync(int id)
            => await _db.Projects.FindAsync(id);

        public async Task<IEnumerable<Project>> GetAllAsync()
            => await _db.Projects.ToListAsync();

        public async Task<bool> UpdateAsync(dynamic entity)
        {
            JsonElement jsonElement = entity;
            var project = new Project
            {
                Id = jsonElement.GetProperty("id").GetInt32(),
                Name = jsonElement.GetProperty("name").GetString(),
                StartDate = jsonElement.GetProperty("startDate").GetDateTime(),
                EndDate = jsonElement.GetProperty("endDate").GetDateTime(),
                ContractorCompany = jsonElement.GetProperty("customerCompany").GetString(),
                CustomerCompany = jsonElement.GetProperty("executorCompany").GetString(),
                ManagerId = jsonElement.GetProperty("managerId").GetInt32(),
                Priority = jsonElement.GetProperty("priority").GetInt32()
            };
            _db.Projects.Update(project);
            await _db.SaveChangesAsync();
            List<int> employeeIds = jsonElement
               .GetProperty("employeeIds")
               .EnumerateArray()
               .Select(x => x.GetInt32())
               .ToList();
            var entriesToDelete = await _db.ProjectEmployees
                .Where(ep=>ep.ProjectId==project.Id)
                .ToListAsync();
            _db.ProjectEmployees.RemoveRange(entriesToDelete);
            foreach (var employeeId in employeeIds)
            {
                var projectEmployee = new ProjectEmployee
                {
                    ProjectId = project.Id,
                    EmployeeId = employeeId
                };
                _db.ProjectEmployees.Add(projectEmployee);
            }
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Projects.FindAsync(id);
            if (entity == null) return false;
            _db.Projects.Remove(entity);
            var entriesToDelete = await _db.ProjectEmployees
                .Where(ep => ep.ProjectId == id)
                .ToListAsync();
            _db.ProjectEmployees.RemoveRange(entriesToDelete);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
