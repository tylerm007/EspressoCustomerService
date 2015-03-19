using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.views;

namespace WebApplication4.Controllers
{
    public class CustomerBusObjectController : ApiController
    {
        // GET api/values
        public dynamic Get()
        {

            return new CustomerVBusObjectView().GetSummary;
        }
    }
}
