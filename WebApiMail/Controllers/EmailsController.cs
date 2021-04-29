using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMail.DbModels;
using WebApiMail.Repository;

namespace WebApiMail.Controllers
{
    [Route("/v1/api/emails")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly EmailsRepository emailsRepository;

        public EmailsController(IConfiguration configuration)
        {
            emailsRepository = new EmailsRepository(configuration);
        }




        // GET: api/<EmailsController>
        [HttpGet]
        public IEnumerable<Emails> Get()
        {
            return emailsRepository.FindAll();
        }    
            

        // POST api/<EmailsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


    }
}
