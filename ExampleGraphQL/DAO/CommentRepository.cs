﻿using CarRentalGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalGraphQL.DAO
{
    public class CommentRepository : ICommentRepository
    {
        private readonly RentalDbContext db;

        public CommentRepository(RentalDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Comment> GetAllComments()
        {
            return db.Comments.AsQueryable();
        }

        public List<Comment> GetCommentsByPostId(long postId)
        {
            return db.Comments.Where(c => c.PostId == postId).ToList();
        }

        public async Task<Comment> AddComment(string content, string author, long postId)
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

        public async Task DeleteComment(long id)
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
