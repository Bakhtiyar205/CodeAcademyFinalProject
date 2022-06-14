using BackFinalProject.Areas.AdminArea.ViewModels;
using BackFinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UsersVM>> AppUsersAsync();
        Task<List<AppUser>> SubscribedUserAsync();
        Task<AppUser> AppUserNameFindAsync(string userName);
        Task<AppUser> AppUserIdAsync(string id);
        Task AppUserActiveAsync(string id);
        Task ChangeModeratorAsync(string id);
        Task ChangeMemberAsync(string id);
    }
}
