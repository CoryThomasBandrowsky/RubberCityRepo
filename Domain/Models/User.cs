using Domain.Enums;
using System;

namespace Domain.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string InputPassword { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public DateTime? MemberSince { get; set; }
        public UserRole UserRole { get; set; }
        public bool NeedsHelp { get; set; }
        public bool CanHelp { get; set; }
        public bool IsLockedOut { get; set; }
        public bool IsBanned { get; set; }
        public bool IsActive { get; set; }
        public bool Credentialed { get; set; }
    }
}
