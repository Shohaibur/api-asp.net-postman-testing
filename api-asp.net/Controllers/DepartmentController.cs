using api_asp.net.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_asp.net.Controllers
{
    public class DepartmentController : ApiController
    {
        [HttpGet]
        [Route("api/departments/all")]
        public HttpResponseMessage Alldept()
        {
            var db = new Entities();

            try {
                var depts = db.Departments.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, depts);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException);
            }
        }
        [HttpGet]
        [Route("api/departments/{id}")]
        public HttpResponseMessage Getdept(int id)
        {
            var db = new Entities();
            try {
                var deptdata = db.Departments.Find(id);
                if (deptdata != null)

                    return Request.CreateResponse(HttpStatusCode.OK, deptdata);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { msg = "Data not found" }); //anonymous object
            }

            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException);
            }

        }
        [HttpPost]
        [Route("api/departments/create")]
        public HttpResponseMessage Create (Department d)
        {
            var db = new Entities();
            try
            {
                db.Departments.Add(d);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, new { Msg = "Created" }); //anonymous object
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException);
            }
            
        }
        [HttpPost]
        [Route("api/departments/update")]
        public HttpResponseMessage Update (Department d)
        {
            var db = new Entities();
            try
            {
                var existeddept = db.Departments.Find(d.Id);
                db.Entry(existeddept).CurrentValues.SetValues(d);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data=existeddept});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.InnerException);
            }
        }
    }
}