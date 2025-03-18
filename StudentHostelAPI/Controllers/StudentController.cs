using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHostel.BLL.Service.IService;
using StudentHostel.DAL.Entites;

namespace StudentHostelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public StudentController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _appUserService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var user = await _appUserService.GetUserByIdAsync(id);
            if (user == null) return NotFound("User Not Found");

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            student.UserType = "Student";
            await _appUserService.AddAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(string id, [FromBody] Student student)
        {
            var existingStudent = await _appUserService.GetByIdAsync(id);
            if (existingStudent == null || existingStudent.UserType != "Student")
                return NotFound("Student not found.");

            student.Id = id.ToString();
            student.UserType = "Student";
            await _appUserService.UpdateAsync(student);
            return NoContent();
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var existingStudent = await _appUserService.GetUserByIdAsync(id);
            if (existingStudent == null )
                return NotFound("Student not found.");

            await _appUserService.DeleteAsync(id);
            return NoContent();
        }
    }
}


