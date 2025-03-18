using Microsoft.AspNetCore.Identity;
using StudentHostel.BLL.Repo;
using StudentHostel.BLL.Repo.IRepo;
using StudentHostel.BLL.Service.IService;
using StudentHostel.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHostel.BLL.Service
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepo _appUserRepository;

        public AppUserService(IAppUserRepo appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }



        public async Task<object?> GetUserByIdAsync(Guid id)
        {
            var user = await _appUserRepository.GetByIdAsync(id);
            if (user == null) return null;

            if (user.UserType == "Owner")
            {
                return new
                {
                    Type = "Owner",
                    Data = new
                    {
                        user.Id,
                        user.UserName,
                        user.Email,
                        user.PhoneNumber,
                    }
                };
            }
            else if (user.UserType == "Student")
            {
                return new
                {
                    Type = "Student",
                    Data = new
                    {
                        user.Id,
                        user.UserName,
                        user.Email,
                        user.PhoneNumber,
                    }
                };
            }

            return user;
        }


        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _appUserRepository.GetAllAsync();
        }

        public async Task<IEnumerable<AppUser>> GetAllStudentsAsync()
        {
            return await _appUserRepository.GetAllByTypeAsync("Student");
        }

        public async Task<IEnumerable<AppUser>> GetAllOwnersAsync()
        {
            return await _appUserRepository.GetAllByTypeAsync("Owner");
        }

        public async Task AddAsync(AppUser user)
        {
            await _appUserRepository.AddAsync(user);
        }

        public async Task UpdateAsync(AppUser user)
        {
            await _appUserRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _appUserRepository.DeleteAsync(id);
        }
        public async Task<AppUser?> GetByIdAsync(string id)
        {
            return await _appUserRepository.GetByStringIdIdAsync(id);
        }
    }
}
