using StudentHostel.DAL.Entites;

namespace StudentHostel.BLL.Repo.IRepo
{
    public interface ICommentRepo
    {
        void AddComment(Comment comment);
        void DeleteComment(int id);
        List<Comment> GetCommentsById(int id);
    }
}