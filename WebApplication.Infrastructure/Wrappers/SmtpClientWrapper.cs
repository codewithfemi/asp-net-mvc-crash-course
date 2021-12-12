using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication3.Core.Interfaces;
using WebApplication3.Core.Models;

namespace WebApplication.Infrastructure.Wrappers
{
    public class SmtpClientWrapper : ISmtpClient
    {
        private readonly SmtpClient _smtpClient;

        public SmtpClientWrapper(IOptions<EmailSettings> emailSettings)
        {
            _smtpClient = new SmtpClient(emailSettings.Value.Host, emailSettings.Value.Port);
            _smtpClient.Credentials = new NetworkCredential(emailSettings.Value.Username, emailSettings.Value.Password);
        }

        public async Task SendAsync(MailMessage mailMessage)
        {
           await _smtpClient.SendMailAsync(mailMessage);
            _smtpClient?.Dispose();
        }
    }
}
