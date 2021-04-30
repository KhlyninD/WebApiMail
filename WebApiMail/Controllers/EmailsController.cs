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

        public EmailsController(EmailsRepository repository)
        {
            emailsRepository = repository;
        }

        // GET: api/<EmailsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(emailsRepository.FindAll());
        }    
            

        // POST api/<EmailsController>
        [HttpPost]
        public IActionResult Post(Emails t)
        {
            emailsRepository.Add(t);
            return Ok();
        }




    }
}
