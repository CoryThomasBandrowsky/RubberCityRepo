using Microsoft.Extensions.Options;
using RubberCity.Data.Interfaces;
using Domain.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RubberCity.Services.Services
{
    public class EmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly IEmailRepository<EmailLog> _emailRepository;
        private readonly IEmailTemplateRepository<EmailTemplate> _emailTemplateRepository;
        private readonly UserService _userService;

        public EmailService( IEmailRepository<EmailLog> emailRepository,
                            IEmailTemplateRepository<EmailTemplate> emailTemplateRepository,
                            UserService userService)
        {
            _userService = userService;
            _emailRepository = emailRepository;
            _emailTemplateRepository = emailTemplateRepository;
            var smtpHost = AppServiceStatic.GetSetting("Email.SmtpHost");
            var smtpPort = Int32.Parse(AppServiceStatic.GetSetting("Email.SmtpPort"));
            var smtpUser = AppServiceStatic.GetSetting("Email.SmtpUser");
            var smtpPass = AppServiceStatic.GetSetting("Email.SmtpPass");


            _smtpClient = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUser, smtpPass),
                EnableSsl = true
            };
        }

        public async Task SendEmailAsync(string toAddress, int templateId)
        {
            try
            {
                var fromAddress = AppServiceStatic.GetSetting("Email.FromAddress");
                var template = await _emailTemplateRepository.GetById(templateId);
                if (template == null)
                {
                    throw new InvalidOperationException("Email template not found");
                }

                var subject = template.Subject;
                var body = template.Body;

                var mailMessage = new MailMessage(fromAddress, toAddress, subject, body)
                {
                    IsBodyHtml = true // Assuming the body contains HTML
                };
                await _smtpClient.SendMailAsync(mailMessage);

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
                throw new InvalidOperationException("Failed to send email", ex);
            }
        }
    }
}
