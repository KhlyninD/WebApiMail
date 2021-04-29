using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApiMail.DbModels;

namespace WebApiMail.Repository
{
    public class EmailsRepository : IRepository<Emails>
    {
        private string connectionString;
        public EmailsRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(Emails item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO emails (RecipientEmails,SubjectEmails,TextEmails,CarbonCopyRecipients,ExceptionPOSTEmails) VALUES(@RecipientEmails,@SubjectEmails,@TextEmails,@CarbonCopyRecipients,@ExceptionPOSTEmails)", item);
            }

        }

        public IEnumerable<Emails> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Emails>("SELECT * FROM emails");
            }
        }

    }
}
