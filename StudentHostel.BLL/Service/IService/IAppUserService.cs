using StudentHostel.DAL.Entites;

namespace StudentHostel.BLL.Service.IService
{
    public interface IAppUserService
    {
        Task AddAsync(AppUser user);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<AppUser>> GetAllAsync();
        Task<IEnumerable<AppUser>> GetAllOwnersAsync();
        Task<IEnumerable<AppUser>> GetAllStudentsAsync();
        Task<AppUser?> GetByIdAsync(string id);
        Task<object?> GetUserByIdAsync(Guid id);
        Task UpdateAsync(AppUser user);
    }
}