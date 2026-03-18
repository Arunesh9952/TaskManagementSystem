using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Services;
using Tasks.DTO;
using Tasks.Models;
using Tasks.Repository;
using Tasks.Services;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserRepository _repo;
        private readonly AuthService _authService;

        public AuthController(UserRepository repo, AuthService authService)
        {
            _repo = repo;
            _authService = authService;
        }
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            _repo.AddUser(user);
            _repo.SaveChanges();
            return Ok(new
            {
                message = "User Registered"
            });
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _repo.GetUserByEmail(dto.Email);

            if (user == null || user.Password != dto.Password)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = _authService.GenerateToken(user);

            return Ok(new
            {
                token = token,
                role = user.Role
            });
        }
    }
}
