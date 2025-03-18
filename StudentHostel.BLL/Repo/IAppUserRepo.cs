using StudentHostel.DAL.Entites;

namespace StudentHostel.BLL.Repo
{
    public interface IAppUserRepo
    {
        Task AddAsync(AppUser user);
        Task AddUserAsync(AppUser newUser);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<AppUser>> GetAllAsync();
        Task<IEnumerable<AppUser>> GetAllByTypeAsync(string userType);
        Task<AppUser?> GetByIdAsync(Guid id);
        Task<AppUser?> GetByStringIdIdAsync(string id);
        Task<AppUser> GetUserByEmailAsync(string email);
        Task UpdateAsync(AppUser user);
    }
}