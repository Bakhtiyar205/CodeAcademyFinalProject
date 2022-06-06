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
       
        public UserController(UserManager<AppUser> user,
                              IUserService userService)
        {
            _user = user;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _userService.AppUsersAsync());
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
