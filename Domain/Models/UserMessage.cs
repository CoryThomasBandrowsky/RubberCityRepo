using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserMessage
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public string message { get; set; }
        public DateTime dateCreated { get; set; }
        public bool needsAttention { get; set; }
        public int urgencyLevel { get; set; }

    }
}
