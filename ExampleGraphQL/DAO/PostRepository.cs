using CarRentalGraphQL;
using CarRentalGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarRentalGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalGraphQL.DAO
{
    public class PostRepository
    {
        private readonly RentalDbContext db;

        public PostRepository(RentalDbContext db)
        {
            this.db = db;
        }

        public List<Post> GetAllPostsOnly()
        {
            return db.Posts.ToList();
        }

        public List<Post> GetAllPostsWithComments()
        {
            return db.Posts.Include(d => d.Comments).ToList();
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

        public async Task DeletePost(Guid id)
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
