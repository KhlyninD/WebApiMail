using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMail.DbModels
{
    public class Emails : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, EmailAddress]
        public string RecipientEmails { get; set; }

        [Required]
        public string SubjectEmails { get; set; }
        [Required]
        public string TextEmails { get; set; }
        
        public string CarbonCopyRecipients { get; set; }
        //[Required]
        public string ExceptionPostEmails { get; set; }


    }
}
