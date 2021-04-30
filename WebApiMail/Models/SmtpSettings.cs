using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMail.Models
{
    public class SmtpSettings
    {
        public string Login { get; set; }

        public string Pass { get; set; }

        public string SmtpHost { get; set; }

        public string SmtpPort { get; set; }
    }
}
