using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentHostel.BLL.Service.TokenService;
using StudentHostel.DAL.Entites;
using StudentHostelAPI.DTO;

namespace StudentHostelAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RegisterRequestDTO _registerRequestDTO;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthController(IAuthenticationService authService, UserManager<AppUser> userManager,
            ILogger<AuthenticationService> logger
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
           _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO request)
        {
            var registerRequest = new RegisterRequestDTO
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,

            };

            var token = await _authService.RegisterAsync(registerRequest);
            if (token == null) return BadRequest("Registration failed");

            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.LoginAsync(request.Email, request.Password);
            if (token == null) return Unauthorized("Invalid credentials");

            return Ok(new { Token = token });
        }
    }

    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
    public class RegisterRequest
    {
        public required string  Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
