using BackFinalProject.Models;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface ISubscriptionService
    {
        Task<AppUser> Subscription(string email, string name);
        Task SendMessageAsync(string email, string name, string content);
    }
}
