using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApplication3.Core.Interfaces
{
    public interface ISmtpClient
    {
        Task SendAsync(MailMessage mailMessage);
    }
}
