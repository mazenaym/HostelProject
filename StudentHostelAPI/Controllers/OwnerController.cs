using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentHostel.BLL.Service;
using StudentHostel.BLL.Service.IService;
using StudentHostel.DAL.Entites;

namespace StudentHostelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        
            private readonly IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IApartmentService _apartmentService;
        public OwnerController(IAppUserService appUserService, UserManager<AppUser> usermanager , IApartmentService apartmentService)
            {
                _appUserService = appUserService;
            _userManager = usermanager;
            _apartmentService = apartmentService;
        }
        
        [HttpGet]
            public async Task<IActionResult> GetAllOwners()
            {
                var owners = await _appUserService.GetAllOwnersAsync();
                return Ok(owners);
            }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            var user = await _appUserService.GetUserByIdAsync(id);
            if (user == null) return NotFound("User Not Found");

            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> AddOwner([FromBody] Owner owner)
        {
            owner.UserType = "Owner";
            await _appUserService.AddAsync(owner);
            return CreatedAtAction(nameof(GetOwnerById), new { id = owner.Id }, owner);
        }

        [HttpPut("{id}")]
            public async Task<IActionResult> UpdateOwner(string id, [FromBody] Owner owner)
            {
                var existingOwner = await _appUserService.GetByIdAsync(id);
                if (existingOwner == null || existingOwner.UserType != "Owner")
                    return NotFound("Owner not found.");

                //owner.Id = id.ToString(); ; 
                owner.UserType = "Owner"; 
                await _appUserService.UpdateAsync(owner);
                return NoContent();
            }
       
        [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteOwner(Guid id)
            {
                var existingOwner = await _appUserService.GetUserByIdAsync(id);
                if (existingOwner == null)
                    return NotFound("Owner not found.");

                await _appUserService.DeleteAsync(id);
                return NoContent();
            }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            var existingOwner = await _appUserService.GetUserByIdAsync(id);

            if (existingOwner == null)
                return NotFound("Owner not found.");
            _apartmentService.DeleteApartmentByOwnerId(id);

            await _appUserService.DeleteAsync(id);
            return NoContent();
        }
    }

    }

