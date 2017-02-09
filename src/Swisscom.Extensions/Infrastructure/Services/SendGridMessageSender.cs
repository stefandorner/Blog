using MailKit.Net.Smtp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Dorner.AspNetCore.Infrastructure
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class SendGridMessageSender : IEmailSender
    {

        private IOptions<InfrastructureOptions> _Options;
        private readonly ILogger _logger;

        public SendGridMessageSender(IOptions<InfrastructureOptions> options, ILoggerFactory loggerFactory)
        {
            _Options = options;
            _logger = loggerFactory.CreateLogger<SendGridMessageSender>();
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {

            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(_Options.Value.Smtp.SenderDisplayName, _Options.Value.Smtp.SenderAddress));
                emailMessage.To.Add(new MailboxAddress(email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("plain")
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_Options.Value.Smtp.Host, _Options.Value.Smtp.Port, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    await client.AuthenticateAsync(_Options.Value.Smtp.Username, _Options.Value.Smtp.Password);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
                // Plug in your email service here to send an email.
                //return Task.FromResult<bool>(true);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            
        }
        
    }
}
