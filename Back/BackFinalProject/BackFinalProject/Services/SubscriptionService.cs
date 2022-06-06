using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.Utilities.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackFinalProject.Services
{
    public class SubscriptionService:ISubscriptionService
    {
        private readonly AppDBContext _context;
        private readonly IMailService _mailService;
        public SubscriptionService(AppDBContext context,
                                   IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }
        public async Task<AppUser> Subscription(string email, string name)
        {
            var subscription = await _context.Users.FirstOrDefaultAsync(m => m.Email.ToLower().Trim() == email.ToLower().Trim()
                                                                        && m.UserName.ToLower().Trim() == name.ToLower().Trim());
            if (subscription is null) return subscription;
            subscription.IsSubscribed = true;
            await _context.SaveChangesAsync();
            string content = "Email For Subscription";
            var mailRequest = new MailRequest
            {
                Subject = content,
                ToEmail = email,
            };
            await _mailService.SendEmailAsync(mailRequest);
            return subscription;
        }
    }
}
