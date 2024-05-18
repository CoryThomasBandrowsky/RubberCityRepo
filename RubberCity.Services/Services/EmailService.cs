using Domain.Models;
using Microsoft.Extensions.Options;
using RubberCity.Data.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RubberCity.Services.Services
{
    public class EmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly AppSettings _appSettings;
        private readonly IEmailRepository<EmailLog> _emailRepository;
        private readonly IEmailTemplateRepository<EmailTemplate> _emailTemplateRepository;
        private readonly UserService _userService;

        public EmailService(IOptionsSnapshot<AppSettings> appSettings,
            IEmailRepository<EmailLog> emailRepository,
            IEmailTemplateRepository<EmailTemplate> emailTemplateRepository,
            UserService userService,
            string smtpHost, int smtpPort, string fromAddress, string smtpUser, string smtpPass)
        {
            _appSettings = appSettings.Value;
            _userService = userService;
            _emailRepository = emailRepository;
            _emailTemplateRepository = emailTemplateRepository;

            _smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(smtpUser, smtpPass),
                EnableSsl = true
            };
        }

        public async Task SendEmailAsync(string toAddress, int templateId, object model)
        {
            try
            {
                var fromAddress = _appSettings.Email.FromAddress;
                var template = await _emailTemplateRepository.GetById(templateId);
                if (template == null)
                {
                    throw new InvalidOperationException("Email template not found");
                }

                var subject = template.Subject; // You can replace placeholders in the subject if needed
                var body = template.Body; // You can replace placeholders in the body if needed

                // Send email
                var mailMessage = new MailMessage(fromAddress, toAddress, subject, body);
                mailMessage.IsBodyHtml = true; // Assuming the body contains HTML
                await _smtpClient.SendMailAsync(mailMessage);

                // Log the sent email
                var emailLog = new EmailLog
                {
                    ToAddress = toAddress,
                    Subject = subject,
                    Body = body,
                    SentAt = DateTime.UtcNow
                };
                await _emailRepository.Add(emailLog);
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can inject an ILogger into EmailService and log the error here
                throw new InvalidOperationException("Failed to send email", ex);
            }
        }
    }
}
