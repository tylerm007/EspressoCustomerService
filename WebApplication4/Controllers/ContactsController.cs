
using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication4.Controllers
{
    public class ContactsController : ApiController
    {
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return new Contact[]{
                new Contact { Id = 1, EmailAddress = "gu@microsoft.com", Name = "ScottGu"},
                new Contact { Id = 2, EmailAddress = "hu@microsoft.com", Name = "ScottHu"},
                new Contact { Id = 3, EmailAddress = "ha@microsoft.com", Name = "ScottHa"},
            };
        }
    }
}
