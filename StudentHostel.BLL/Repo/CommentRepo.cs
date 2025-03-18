using StudentHostel.BLL.Repo.IRepo;
using StudentHostel.DAL.Database;
using StudentHostel.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHostel.BLL.Repo
{
    public class CommentRepo : ICommentRepo
    {
        private readonly ApplicationDbContext _context;
        public CommentRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        //add comment
        public void AddComment(Comment comment)
        {
            _context.comments.Add(comment);
            _context.SaveChanges();
        }
        //delete commentt 
        // Delete a comment by ID
        public void DeleteComment(int id)
        {
            var comment = _context.comments.Find(id);
            if (comment != null)
            {
                _context.comments.Remove(comment);
                _context.SaveChanges();
            }
        }
        public List<Comment> GetCommentsById(int id)
        {
            return _context.comments.Where(c => c.Apartment_Id == id).ToList();
        }


    }
}

