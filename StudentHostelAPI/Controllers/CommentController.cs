using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentHostel.BLL.DTO;
using StudentHostel.BLL.Service.IService;
using StudentHostel.DAL.Entites;
using System.Security.Claims;

namespace StudentHostelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }
       
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CommentDTO commentdto)
        {
            if (commentdto == null )
            {
                return BadRequest(new { message = "Invalid comment data" });
            }
            var UserEmail = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(UserEmail);
            var comment = new Comment
            {
                StudentId = user.Id,
                Comment_Text = commentdto.Comment_Text,
                Apartment_Id = commentdto.Apartment_Id,
               
            };

            
            _commentService.AddComment(comment);

            return Ok(new { message = "Comment added successfully." });
        }
        [HttpGet("{id}")]
        public IActionResult GetCommentsById(int id)
        {
            var comments = _commentService.GetCommentsById(id);

            if (comments == null || !comments.Any())
            {
                return NotFound(new { message = $"No comments found with ID {id}." });
            }

            return Ok(comments);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id, [FromBody] Comment comment)
        {
            var existingComment = _commentService.GetCommentsById(id);
            if (existingComment == null)
            {
                return NotFound(new { message = $"Comment with ID {id} not found." });
            }
            _commentService.DeleteComment(id);
            return NoContent();
        }
    }
}
