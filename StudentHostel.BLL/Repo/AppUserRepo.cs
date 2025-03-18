using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentHostel.DAL.Database;
using StudentHostel.DAL.Entites;

namespace StudentHostel.BLL.Repo
{
    public class AppUserRepo : IAppUserRepo
    {
        private readonly ApplicationDbContext _context;


        public AppUserRepo(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<AppUser?> GetByIdAsync(Guid id)
        {
            string stringId = id.ToString(); // تحويل GUID لـ string
            return await _context.Set<AppUser>().FindAsync(stringId);

        }

        public async Task<AppUser> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FindAsync(email);
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<AppUser>> GetAllByTypeAsync(string userType)
        {
            return await _context.Users.Where(u => u.UserType == userType).ToListAsync();
        }


        public async Task AddAsync(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AppUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            string stringId = id.ToString();
            var user = await _context.Set<AppUser>().FindAsync(stringId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            await _context.Set<AppUser>().FindAsync(stringId);
        }

        public Task AddUserAsync(AppUser newUser)
        {
            throw new NotImplementedException();
        }
        public async Task<AppUser?> GetByStringIdIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
