using StudentHostel.DAL.Entites;

namespace StudentHostel.BLL.Service.TokenService
{
    public interface ITokenService
    {
      Task<string> CreateTokenAsyn(AppUser User);
    }
}