using CarRentalGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalGraphQL.DAO
{
    public class PostRepository : IPostRepository
    {
        private readonly RentalDbContext db;

        public PostRepository(RentalDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Post> GetAllPostsOnly()
        {
            return db.Posts.AsQueryable();
        }

        public IQueryable<Post> GetAllPostsWithComments()
        {
            return db.Posts.Include(d => d.Comments).AsQueryable();
        }

        public async Task<Post> AddPost(string title, string content, string author)
        {
            Post post = new Post
            {
                Author = author,
                Content = content,
                Title = title
            };
            db.Posts.Add(post);
            await db.SaveChangesAsync();
            return post;
        }

        public async Task<Post> UpdatePost(Post model)
        {
            var post = await db.Posts.Where(p => p.Id == model.Id).FirstOrDefaultAsync();
            if (post != null)
            {
                if (!string.IsNullOrEmpty(model.Title))
                    post.Title = model.Title;
                if (!string.IsNullOrEmpty(model.Content))
                    post.Content = model.Content;
                if (!string.IsNullOrEmpty(model.Author))
                    post.Author = model.Author;
                post.CreateAt = DateTime.Now;
                db.Posts.Update(post);
                await db.SaveChangesAsync();
            }
            return post;
        }

        public async Task DeletePost(long id)
        {
            var post = await db.Posts.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (post != null)
            {
                db.Posts.Remove(post);
                await db.SaveChangesAsync();
            }
        }
    }
}
