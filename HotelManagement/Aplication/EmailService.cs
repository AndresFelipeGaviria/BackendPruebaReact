using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace HotelManagement.Aplication
{
    public class EmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _fromEmail = "managemenreservationhotel@gmail.com"; 
        private readonly string _password = "prturtbfdvjebltv"; 

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_fromEmail));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart("html") { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_fromEmail, _password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
