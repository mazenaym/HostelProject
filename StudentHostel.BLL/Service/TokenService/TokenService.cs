using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentHostel.DAL.Entites;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentHostel.BLL.Service.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> CreateTokenAsyn(AppUser User)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, User.UserName),
        new Claim(ClaimTypes.NameIdentifier, User.Id),
        new Claim(ClaimTypes.HomePhone, User.PhoneNumber),
        new Claim(ClaimTypes.Email, User.Email),
        new Claim(ClaimTypes.Role, User.UserType),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
