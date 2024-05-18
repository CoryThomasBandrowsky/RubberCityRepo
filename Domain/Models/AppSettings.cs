namespace Domain.Models
{
    public class AppSettings
    {
        public string TestValue { get; set; }
        public string Environment { get; set; }
        public string DefaultProfilePicture { get; set; }
        public PayPalSettings PayPal { get; set; }
        public EmailSettings Email { get; set; }
    }

    public class PayPalSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Mode { get; set; }
    }

    public class EmailSettings
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string FromAddress { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
    }
}
