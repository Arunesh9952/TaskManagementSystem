using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Data;

namespace TaskMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("tasks")]
        public IActionResult GetAllTasks()
        {
            var tasks = _context.Tasks.ToList();
            return Ok(tasks);
        }


        [HttpGet("stats")]
        public IActionResult Stats()
        {
            var totalUsers = _context.Users.Count();
            var totalTasks = _context.Tasks.Count();
            var completed = _context.Tasks.Count(x => x.Status == "Completed");

            return Ok(new
            {
                totalUsers,
                totalTasks,
                completed
            });

        }

    }
}