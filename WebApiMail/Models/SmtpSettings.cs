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

        public string SntpHost { get; set; }

        public string SntpPort { get; set; }
    }
}
