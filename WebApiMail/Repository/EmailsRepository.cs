using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using WebApiMail.DbModels;
using WebApiMail.Models;
using WebApiMail.Smtp;

namespace WebApiMail.Repository
{
    public class EmailsRepository : IRepository<Emails>
    {
        private DbSettings connectionString;
        private SmtpSettings settingSmtpSettings;


        public EmailsRepository(IOptionsMonitor<DbSettings> settingDb, IOptionsMonitor<SmtpSettings> settingSmtp)
        {
            connectionString = settingDb.CurrentValue;
            settingSmtpSettings = settingSmtp.CurrentValue; 
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString.ConnectionString);
            }
        }

        public void Add(Emails item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                item.ExceptionPostEmails = EmailsSend.CreateMessage(item, settingSmtpSettings);
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO emails (RecipientEmails,SubjectEmails,TextEmails,CarbonCopyRecipients,ExceptionPOSTEmails) " +
                    "VALUES(@RecipientEmails,@SubjectEmails,@TextEmails,@CarbonCopyRecipients,@ExceptionPOSTEmails)", item);
            }

        }

        public IEnumerable<Emails> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                //EmailsSend.CreateMessage();
                dbConnection.Open();
                return dbConnection.Query<Emails>("SELECT * FROM emails");
            }
        }

    }
}
