using StudentHostel.DAL.Entites;
using StudentHostelAPI.DTO;

namespace StudentHostel.BLL.Service.TokenService
{
    public interface IAuthenticationService
    {
        Task<string?> LoginAsync(string username, string password);
        Task<string?> RegisterAsync(RegisterRequestDTO request);
    }
}