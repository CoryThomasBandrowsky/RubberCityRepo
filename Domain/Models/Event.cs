using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Event
    {
        public int ID { get; set; }
        public int HostedByUserID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublic { get; set; }
        public bool IsFree { get; set; }
        public bool IsDonationRequired { get; set; }
    }

}
