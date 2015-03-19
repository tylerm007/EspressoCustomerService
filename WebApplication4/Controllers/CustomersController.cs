using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Model;
using WebApplication4.Helpers;
using WebApplication4.views;

namespace WebApplication4.Controllers
{
    public class CustomersController : ApiController
    {

        // GET api/values
        public CustomerList Get()
        {

             return new CustomerView().CustomerSummary;
        }

        // GET api/values/5
        public Customer GetById(string id)
        {
            return new CustomerView(id).SingleCustomer;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
