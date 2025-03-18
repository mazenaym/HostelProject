using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StudentHostel.DAL.Entites;
using StudentHostelAPI.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentHostel.BLL.Service.TokenService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;

        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public AuthenticationService(UserManager<AppUser> userManager, IConfiguration configuration,
            ILogger<AuthenticationService> logger,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _tokenService = tokenService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string?> RegisterAsync(RegisterRequestDTO request)
        {
            var user = new AppUser
            {
                UserName = request.Username,
                Email = request.Email,
                UserType = request.Role,
                PhoneNumber= request.PhoneNumber,
                FirstName = "Default",
                LastName = "User"
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return null;
            }

            return await _tokenService.CreateTokenAsyn(user);
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                return null;
            }

            return await _tokenService.CreateTokenAsyn(user);
        }
    }
}

  