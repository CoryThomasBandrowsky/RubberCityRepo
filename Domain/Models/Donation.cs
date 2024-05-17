using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Donation
    {
        public int ID { get; set; }
        public string DonorName { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; }
        public string PaymentId { get; set; }
    }
}

