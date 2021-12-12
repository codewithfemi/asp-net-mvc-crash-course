using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication3.Core.Interfaces;

namespace WebApplication.Infrastructure.Services
{
    public class EmailService : IEmailSender
    {
        private readonly ISmtpClient _smtpClient;

        public EmailService(ISmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mailMessage = new MailMessage("noreply@mvcapp.com", email);
            mailMessage.Subject = subject;
            mailMessage.Body = htmlMessage;
            mailMessage.IsBodyHtml = true;

            await _smtpClient.SendAsync(mailMessage);
        }
    }
}
