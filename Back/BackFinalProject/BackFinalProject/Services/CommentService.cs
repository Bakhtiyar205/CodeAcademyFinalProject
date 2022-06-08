using BackFinalProject.Areas.AdminArea.ViewModels;
using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDBContext context;

        public CommentService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task PostCommentAsync(int productId,string name, string comment)
        {
            Comment newComment = new()
            {
                Name = name,
                CommentSection = comment,
                ProductId = productId
            };
            await context.Comments.AddAsync(newComment);
            await context.SaveChangesAsync();
        }

        public async Task<List<CommentVM>> GetCommentsAsync()
        {
            List<CommentVM> commentVM = new();
            foreach (var comment in await context.Comments.ToListAsync())
            {
                CommentVM newComment = new()
                {
                    Comment = comment,
                    Product = await context.Products.FirstOrDefaultAsync(m => m.Id == comment.ProductId)
                };

                commentVM.Add(newComment);
            }
            return commentVM;
        }

        public async Task ApproveDisApproveCommentAsync(int id)
        {
            Comment comment = await context.Comments.FirstOrDefaultAsync(m => m.Id == id);
            if (!comment.IsConfirmed)
            {
                comment.IsConfirmed = true;
            }
            else
            {
                comment.IsConfirmed = false;
            }
            await context.SaveChangesAsync();
        }
        public async Task<List<Comment>> GetSpecialProductCommentsAsync(int productId)
        {
            List<Comment> comments = new();
            var dbComments = await context.Comments.Where(m=>m.ProductId == productId && m.IsConfirmed).ToListAsync();
            if(dbComments != null)
            {
                foreach (var dbComment in dbComments)
                {
                    comments.Add(dbComment);
                }
            }
            return comments;
        }
    }
}
