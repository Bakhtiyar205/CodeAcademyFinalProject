using BackFinalProject.Utilities.Helpers;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
