using StudentHostel.BLL.Repo.IRepo;
using StudentHostel.BLL.Service.IService;
using StudentHostel.DAL.Entites;

namespace StudentHostel.BLL.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepository;
        public CommentService(ICommentRepo commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public void AddComment(Comment comment)
        {
            _commentRepository.AddComment(comment);
        }
        public void DeleteComment(int id)
        {
            _commentRepository.DeleteComment(id);
        }
        public List<Comment> GetCommentsById(int id)
        {
            return _commentRepository.GetCommentsById(id);
        }
    }
}
