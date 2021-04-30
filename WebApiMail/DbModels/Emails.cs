using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace WebApiMail.DbModels
{

    public class Emails : BaseEntity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required, EmailAddress]
        public string RecipientEmails { get; set; }

        [Required]
        public string SubjectEmails { get; set; }
        [Required]
        public string TextEmails { get; set; }
        
        public string[] CarbonCopyRecipients { get; set; }
        
        public string ExceptionPostEmails { get; set; }







    }
}
