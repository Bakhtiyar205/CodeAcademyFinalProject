using BackFinalProject.Areas.AdminArea.ViewModels;
using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BackFinalProject.Utilities.Helpers.Helper;

namespace BackFinalProject.Services
{
    public class UserService:IUserService
    {
        private readonly AppDBContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(AppDBContext context,
                           UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<List<UsersVM>> AppUsersAsync()
        {
            List<UsersVM> users = new();

            var dbUsers = await context.Users.ToListAsync();

            foreach (var item in dbUsers)
            {
                UsersVM newUser = new UsersVM
                {
                    User = item,
                    IsModerator = await AppUserRolesAsync(item)
                };

                users.Add(newUser);
            }

           return users;
        }

        public async Task<AppUser> AppUserNameFindAsync(string userName)
        {
            return await context.Users.FirstOrDefaultAsync(m=>m.UserName == userName);
        }

        public async Task<bool> AppUserRolesAsync(AppUser user) 
        {
            var roleId = context.Roles.Where(r => r.Name == "Moderator").Select(r => r.Id).FirstOrDefaultAsync();
            if(await context.UserRoles.Where(m => m.UserId == user.Id && m.RoleId == roleId.Result).FirstOrDefaultAsync() != null)
            {
                return true;
            }
            else
            {
                return false;
            }

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
            var roles = await userManager.GetRolesAsync(moderator);
            await context.SaveChangesAsync();
        }

        public async Task ChangeMemberAsync(string id)
        {
            AppUser member = await AppUserIdAsync(id);
            await userManager.RemoveFromRoleAsync(member, UserRoles.Moderator.ToString());
            await context.SaveChangesAsync();
        }
    }
}
