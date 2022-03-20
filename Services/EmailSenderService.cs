using Ans.Net6.Common;
using Ans.Net6.Common.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace Ans.Net6.Web.Services
{

	public class EmailSenderService
        : IEmailSender
    {
        private readonly MailerService _mailer;

        public EmailSenderService(
            IConfiguration configuration)
        {
            var options = configuration
                .GetSection(LibOptions.Name)
                .Get<LibOptions>();
            _mailer = new MailerService(options.MailService);
        }

        public async Task SendEmailAsync(
            string email,
            string subject,
            string htmlMessage)
        {
            await _mailer.SendAsync(new MailMessage
            {
                To = new MailAddress(email),
                Subject = subject,
                ContentHtml = htmlMessage
            });
            //await Task.CompletedTask;
        }
    }

}
