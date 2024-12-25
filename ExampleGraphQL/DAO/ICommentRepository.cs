using CarRentalGraphQL.Models;
using System.Linq;

namespace CarRentalGraphQL.DAO
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetAllComments();
        Task<Comment> AddComment(string content, string author, Guid postId);
        Task<Comment> UpdateComment(Comment model);
        Task DeleteComment(Guid id);
        List<Comment> GetCommentsByPostId(Guid postId);
    }
}
