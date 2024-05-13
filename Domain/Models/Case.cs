using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Case
    {
        public Guid ID { get; set; }
        public int UserID { get; set; }
        public int HelpRequestID { get; set; }
        public bool IsActive { get; set; }
        public string Summary { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateClosed { get; set; }
    }
}
