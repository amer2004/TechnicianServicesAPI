using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace TechnicalServicesAPI.Classes
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string Message)
        {
            var Mail = "";
            var Pass = "";

            var Client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(Mail, Pass),
            };

            await Client.SendMailAsync(new MailMessage(from: Mail, to: email, subject, Message));

        }
    }
}
