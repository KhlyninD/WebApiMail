using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApiMail.DbModels;
using WebApiMail.Models;

namespace WebApiMail.Smtp
{
    public class EmailsSend
    {

        public static string CreateMessage(Emails item, SmtpSettings smtpSettings)
        {
            var emailBool = new EmailAddressAttribute();
            MailMessage mail = new();
            mail.To.Add(item.RecipientEmails);
            
            
            mail.From = new MailAddress(smtpSettings.Login);

            mail.Subject = item.SubjectEmails;
            mail.Body = item.TextEmails;
            mail.IsBodyHtml = true;

            if (item.CarbonCopyRecipients != null)
            {
                string[] copy = item.CarbonCopyRecipients;
                foreach (var i in copy)
                {
                    if (emailBool.IsValid(i)) { mail.CC.Add(i);}
                    else { return "Неверный email получателя копии"; }   
                }
            }
            
            
            using (SmtpClient smtp = new())
            {
                //SmtpClient smtp = new();
                smtp.Host = smtpSettings.SmtpHost;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(smtpSettings.Login, smtpSettings.Pass);
                try
                {
                    smtp.Send(mail);

                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }

            }
            return "ok";


        }
    }
}
