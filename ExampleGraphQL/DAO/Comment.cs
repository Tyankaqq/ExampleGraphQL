using CarRentalGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalGraphQL.DAO
{
    public class CommentRepository
    {
        private readonly RentalDbContext db;

        public CommentRepository(RentalDbContext db)
        {
            this.db = db;
        }

        public List<Comment> GetAllComments()
        {
            return db.Comments.ToList();
        }

        public List<Comment> GetCommentsByPostId(Guid postId)
        {
            return db.Comments.Where(c => c.PostId == postId).ToList();
        }

        public async Task<Comment> AddComment(string content, string author, Guid postId)
        {
            Comment comment = new Comment
            {
                Author = author,
                Content = content,
                PostId = postId
            };
            db.Comments.Add(comment);
            await db.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> UpdateComment(Comment model)
        {
            var comment = await db.Comments.Where(c => c.Id == model.Id).FirstOrDefaultAsync();
            if (comment != null)
            {
                if (!string.IsNullOrEmpty(model.Content))
                    comment.Content = model.Content;
                if (!string.IsNullOrEmpty(model.Author))
                    comment.Author = model.Author;
                comment.CreatedAt = DateTime.Now;
                db.Comments.Update(comment);
                await db.SaveChangesAsync();
            }
            return comment;
        }

        public async Task DeleteComment(Guid id)
        {
            var comment = await db.Comments.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (comment != null)
            {
                db.Comments.Remove(comment);
                await db.SaveChangesAsync();
            }
        }
    }
}
