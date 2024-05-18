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
        private readonly AppSettings _appSettings;
        private readonly IEmailRepository<EmailLog> _emailRepository;
        private readonly IEmailTemplateRepository<EmailTemplate> _emailTemplateRepository;
        private readonly UserService _userService;

        public EmailService(IOptions<AppSettings> appSettings,
                            IEmailRepository<EmailLog> emailRepository,
                            IEmailTemplateRepository<EmailTemplate> emailTemplateRepository,
                            UserService userService)
        {
            _appSettings = appSettings.Value;
            _userService = userService;
            _emailRepository = emailRepository;
            _emailTemplateRepository = emailTemplateRepository;

            _smtpClient = new SmtpClient(_appSettings.Email.SmtpHost, _appSettings.Email.SmtpPort)
            {
                Credentials = new NetworkCredential(_appSettings.Email.SmtpUser, _appSettings.Email.SmtpPass),
                EnableSsl = true
            };
        }

        public async Task SendEmailAsync(string toAddress, int templateId)
        {
            try
            {
                var fromAddress = _appSettings.Email.FromAddress;
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
