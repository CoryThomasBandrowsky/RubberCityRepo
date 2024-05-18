using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class LocalHelp
    {
        public int Id { get; set; }
        public string linkUrl { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
