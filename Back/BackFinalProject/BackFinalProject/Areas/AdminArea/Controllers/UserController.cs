using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _user;
        private readonly IUserService _userService;
        private readonly ISubscriptionService subscriptionService;

        public UserController(UserManager<AppUser> user,
                              IUserService userService,
                              ISubscriptionService subscriptionService)
        {
            _user = user;
            _userService = userService;
            this.subscriptionService = subscriptionService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _userService.AppUsersAsync());
        }

        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(string Message)
        {
            if(Message == null)
            {
                ModelState.AddModelError("", "Please write your message");
            }
            foreach (var user in await _userService.SubscribedUserAsync())
            {
               await subscriptionService.SendMessageAsync(user.Email, user.UserName, Message);
            }    
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Active(string id)
        {
            await _userService.AppUserActiveAsync(id);
            return RedirectToAction(nameof(Index), "User");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsModerator(string id)
        {
            await _userService.ChangeModeratorAsync(id);
            return RedirectToAction(nameof(Index), "User");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsMember(string id)
        {
            await _userService.ChangeMemberAsync(id);
            return RedirectToAction(nameof(Index), "User");
        }

    }
}
