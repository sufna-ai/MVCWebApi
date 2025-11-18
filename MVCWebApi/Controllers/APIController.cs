using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCWebApi.Controllers
{
    public class APIController : ApiController
    {
        MVC_EFEntities db = new MVC_EFEntities();
        // GET: api/API
        [HttpGet]        //used to set which hhtp method used for the action
        [Route("api/API/getstudents")]    //used to set the route to url of the action
        public IHttpActionResult Get()
        {
            return Ok(db.students.ToList());
        }

        // GET: api/API/5
        [HttpGet]
        [Route("api/API/getstudent/{id}")]
        public IHttpActionResult Get(int id)
        {
            student std = db.students.Find(id);
            if (std == null)
            {
                return NotFound();
            }
            return Ok(std);

        }

        // POST: api/API
        [HttpPost]
        [Route("api/API/addstudent")]
        public IHttpActionResult Post(student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return Ok(200);
            }
            return BadRequest();
            
        }

        // PUT: api/API/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/API/5
        [HttpDelete]
        [Route("api/API/deletestudent/{id}")]
        public IHttpActionResult Delete(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
            db.SaveChanges();
            return Ok(student);
        }

        // EDIT: api/API
        [HttpPost]
        [Route("api/API/editstudent")]
        public IHttpActionResult Edit(student stu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stu).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(200);
            }
            return BadRequest();
        }
    }
}
