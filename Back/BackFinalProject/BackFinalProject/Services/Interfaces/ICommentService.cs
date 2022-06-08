using BackFinalProject.Areas.AdminArea.ViewModels;
using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface ICommentService
    {
        Task PostCommentAsync(int producId,string name, string comment);
        Task<List<CommentVM>> GetCommentsAsync();
        Task ApproveDisApproveCommentAsync(int id);
        Task<List<Comment>> GetSpecialProductCommentsAsync(int productId);
    }
}
