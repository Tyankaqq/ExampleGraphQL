using CarRentalGraphQL.Models;
using System.Linq;

namespace CarRentalGraphQL.DAO
{
    public interface IPostRepository
    {
        IQueryable<Post> GetAllPostsOnly();
        IQueryable<Post> GetAllPostsWithComments();
        Task<Post> AddPost(string title, string content, string author);
        Task<Post> UpdatePost(Post model);
        Task DeletePost(Guid id);
    }
}
