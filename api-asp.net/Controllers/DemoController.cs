using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_asp.net.Controllers
{
    public class DemoController : ApiController
    {
        [HttpGet]
        [Route("api/names")]
        public HttpResponseMessage Get()
        {
            var names = new string[] { "Shoaib", "Rochi" };
            return Request.CreateResponse(HttpStatusCode.OK, names);
        }
        [HttpGet]
        [Route("api/name/{st_id}")]
        public HttpResponseMessage GetName(int st_id) //custom methos name GetName
        {
            string name = st_id == 1 ? "Rochi" : "Not found";
            return Request.CreateResponse(HttpStatusCode.OK, name);
        }
        [HttpPost]
        [Route("api/test/post")] //post test using postman
        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Post recieved");
        }
    }
}
