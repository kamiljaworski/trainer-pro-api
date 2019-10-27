namespace TrainerPro.Services.Services
{
    using Microsoft.AspNetCore.Identity.UI.Services;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _smtpClient;
        private string _username;

        public EmailSender(string host, int port, bool enableSSL, string username, string password)
        {
            _username = username;
            _smtpClient = new SmtpClient(host, port)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(username, password),
                EnableSsl = enableSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
        }
        
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await _smtpClient.SendMailAsync(new MailMessage(_username, email, subject, htmlMessage) { IsBodyHtml = true });
        }
    }
}
