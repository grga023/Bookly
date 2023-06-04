using Bookly.Domain.Apstrakcije;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Bookly.Infrastructure.Email
{
    public class EmailServis : IEmailServis
    {
        private SmtpGoogleKonfiguracija _smtpGoogleKonfiguracija;
        public EmailServis(IOptions<SmtpGoogleKonfiguracija> options)
        {
            _smtpGoogleKonfiguracija = options.Value ?? throw new ArgumentNullException(nameof(options));
        }
        public async Task PosaljiAsync(string to, string message, string subject)
        {
            using var client = new SmtpClient();
            client.Host = _smtpGoogleKonfiguracija.Host;
            client.Port = _smtpGoogleKonfiguracija.Port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(_smtpGoogleKonfiguracija.Username, _smtpGoogleKonfiguracija.Password);
            using var msg = new MailMessage(
                from: new MailAddress("tfzrbookly@gmail.com"),
                to: new MailAddress(to)
                );

            msg.Subject = subject;
            msg.Body = message;

            await client.SendMailAsync(msg);
        }
    }
}