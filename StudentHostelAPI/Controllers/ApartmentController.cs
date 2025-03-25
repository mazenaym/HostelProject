using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentHostel.BLL.DTO;
using StudentHostel.BLL.Service.IService;
using StudentHostel.DAL.Entites;
using System.Net;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentHostelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;
        private readonly UserManager<AppUser> _userManager;

        public ApartmentController(IApartmentService apartmentService,
            UserManager<AppUser> userManager)
        {
            _apartmentService = apartmentService;
            _userManager = userManager;
        }
       
        [HttpGet("GetAll")]
        public IActionResult GetAllApartments()
        {
            var apartments = _apartmentService.GetAllApartment();
            return Ok(apartments);
        }

       
        [HttpGet("{id}")]
        public IActionResult GetApartmentById(int id)
        {
            var apartment = _apartmentService.GetApartmentById(id);
            if (apartment == null)
            {
                return NotFound(new { message = $"Apartment with ID {id} not found." });
            }
            return Ok(apartment);
        }

       
        [HttpPost]
        
        public async Task<IActionResult> AddApartment([FromForm] ApartmentDTO apartmentDTO)
        {
            if (apartmentDTO == null || apartmentDTO.Apartment_Image == null)
            {
                return BadRequest(new { message = "Invalid apartment data or missing image." });
            }

      var UserEmail=User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(UserEmail);
            using var stream = new MemoryStream();
            await apartmentDTO.Apartment_Image.CopyToAsync(stream);

            var apartment = new Apartment
            {
                OwnerId = user.Id,
                Price = apartmentDTO.Price,
                Title = apartmentDTO.Title,
                Description = apartmentDTO.Description,
                Address = apartmentDTO.Address,
                FloorNum = apartmentDTO.FloorNum,
                Num_Room = apartmentDTO.Num_Room,
                Num_Bed = apartmentDTO.Num_Bed,
                Publisheddate = apartmentDTO.Publisheddate,
                Apartment_Image = stream.ToArray(),
                IsRented = apartmentDTO.IsRented,
            };

            _apartmentService.AddApartment(apartment);
            return Ok(new { message = "Apartment added successfully." });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateApartment(int id, [FromBody] Apartment updatedApartment)
        {
            if (updatedApartment == null || id != updatedApartment.Apartment_Id)
            {
                return BadRequest(new { message = "Invalid request data." });
            }

            var existingApartment = _apartmentService.GetApartmentById(id);
            if (existingApartment == null)
            {
                return NotFound(new { message = $"Apartment with ID {id} not found." });
            }

            existingApartment.Title = !string.IsNullOrEmpty(updatedApartment.Title) ? updatedApartment.Title : existingApartment.Title;
            existingApartment.Address = !string.IsNullOrEmpty(updatedApartment.Address) ? updatedApartment.Address : existingApartment.Address;
            existingApartment.Description = !string.IsNullOrEmpty(updatedApartment.Description) ? updatedApartment.Description : existingApartment.Description;
            existingApartment.Num_Bed = updatedApartment.Num_Bed != 0 ? updatedApartment.Num_Bed : existingApartment.Num_Bed;
            existingApartment.Num_Room = updatedApartment.Num_Room != 0 ? updatedApartment.Num_Room : existingApartment.Num_Room;
            existingApartment.FloorNum = updatedApartment.FloorNum != 0 ? updatedApartment.FloorNum : existingApartment.FloorNum;
            existingApartment.Price = updatedApartment.Price != 0 ? updatedApartment.Price : existingApartment.Price;
            existingApartment.IsRented = updatedApartment.IsRented;
            existingApartment.OwnerId = !string.IsNullOrEmpty(updatedApartment.OwnerId) ? updatedApartment.OwnerId : existingApartment.OwnerId;
            existingApartment.Apartment_Image = updatedApartment.Apartment_Image ?? existingApartment.Apartment_Image;

            _apartmentService.UpdateApartment(existingApartment);

            return Ok(new { message = "Apartment updated successfully.", apartment = existingApartment });
        }




        [HttpDelete("{id}")]
        public IActionResult DeleteApartment(int id)
        {
            var existingApartment = _apartmentService.GetApartmentById(id);
            if (existingApartment == null)
            {
                return NotFound(new { message = $"Apartment with ID {id} not found." });
            }
            _apartmentService.DeleteApartment(id);
            return NoContent();
        }



    }
}
