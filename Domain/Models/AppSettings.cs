﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AppSettings
    {
        public string TestValue { get; set; }
        public string Environment { get; set; }
        public string DefaultProfilePicture { get; set; }
        public string PaypalClientId { get; set; }
        public string PayPalClientSecret { get; set; }
        public string PayPalMode { get; set; }
    }
}
