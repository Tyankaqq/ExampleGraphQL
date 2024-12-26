using CarRentalGraphQL.Models;
using System.Linq;

namespace CarRentalGraphQL.DAO
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetAllComments();
        Task<Comment> AddComment(string content, string author, long postId);
        Task<Comment> UpdateComment(Comment model);
        Task DeleteComment(long id);
        List<Comment> GetCommentsByPostId(long postId);
    }
}
