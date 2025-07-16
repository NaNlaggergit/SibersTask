using Microsoft.AspNetCore.Mvc;
using SibersTask.Infrastructure.Data;
using SibersTask.Domain.Entities;

namespace SibersTask.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TestController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("add-project")]
        public IActionResult AddProject([FromBody] Project project)
        {
            _db.Projects.Add(project);
            _db.SaveChanges();
            return Ok(project);
        }
    }
}