using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BackFinalProject.Utilities.Helpers.Helper;

namespace BackFinalProject.Services
{
    public class UserService:IUserService
    {
        private readonly AppDBContext context;
        private readonly UserManager<AppUser> userManager;

        public UserService(AppDBContext context,
                           UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<List<AppUser>> AppUsersAsync()
        {
           return await context.Users.ToListAsync();
        }

        public async Task<AppUser> AppUserNameFindAsync(string userName)
        {
            return await context.Users.FirstOrDefaultAsync(m=>m.UserName == userName);
        }

        public async Task<AppUser> AppUserIdAsync(string id)
        {
            return await context.Users.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AppUserActiveAsync(string id)
        {
            AppUser appUser = await AppUserIdAsync(id);
            if (appUser.IsActivated)
            {
                appUser.IsActivated = false;
            }
            else
            {
                appUser.IsActivated = true;
            }
            await context.SaveChangesAsync();
        }

        public async Task ChangeModeratorAsync(string id)
        {
            AppUser moderator = await AppUserIdAsync(id);
            await userManager.AddToRoleAsync(moderator, UserRoles.Moderator.ToString());
            await context.SaveChangesAsync();
        }

        public async Task ChangeMemberAsync(string id)
        {
            AppUser member = await AppUserIdAsync(id);
            await userManager.AddToRoleAsync(member, UserRoles.Member.ToString());
            await context.SaveChangesAsync();
        }
    }
}
