using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AppSettings
    {
        public int ID { get; set; }
        public string project { get; set; }
        public string json { get; set; }
        public string environment { get; set; }
    }
}
