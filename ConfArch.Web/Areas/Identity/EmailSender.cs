using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace ConfArch.Web.Areas.Identity
{
    public class EmailSender : IEmailSender, ITestEmailSender
    {
        private readonly string _apiKey;
        private readonly string _fromName;
        private readonly string _fromEmail;
        private readonly ILogger<EmailSender> _logger;


        public EmailSender(IConfiguration config, ILogger<EmailSender> logger)
        {
            _apiKey = config["SendGrid:ApiKey"];
            _fromEmail = config["SendGrid:FromEmail"];
            _fromName = config["SendGrid:FromName"];
            _logger = logger;

        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(_apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_fromEmail, _fromName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Dissable click tracking
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            await client.SendEmailAsync(msg);
        }

        public async Task SendTestEmailAsync()
        {
            var apiKey = _apiKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("wojciech.cz7@gmail.com", "Wojtek");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("wojciech.cz7@gmail.com", "Wojtek");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg); 

            _logger.LogInformation(response.StatusCode.ToString());
            _logger.LogInformation(response.Body.ReadAsStringAsync().Result); // The message will be here
            _logger.LogInformation(response.Headers.ToString());
            _logger.LogInformation($"fromEmail: {from.Email}, fromName: {from.Name}");
            _logger.LogInformation($"response.StatusCode: { response.StatusCode.ToString()} ");

        }
    }
}
