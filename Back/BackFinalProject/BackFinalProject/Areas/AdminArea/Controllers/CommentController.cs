using BackFinalProject.Areas.AdminArea.ViewModels;
using BackFinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin,Moderator")]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await commentService.GetCommentsAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveDisapproveComments(int id)
        {
            await commentService.ApproveDisApproveCommentAsync(id);
            return RedirectToAction(nameof(Index), "Comment");
        }
    }
}
