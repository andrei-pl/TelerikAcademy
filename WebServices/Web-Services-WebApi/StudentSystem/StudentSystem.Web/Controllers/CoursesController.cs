namespace StudentSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Data.Repositories;
    using StudentSystem.Web.Models;

    public class CoursesController : ApiController
    {
        private IGenericRepository<Course> co;
        private StudentsSystemData db = new StudentsSystemData();

        public CoursesController()
            : this(new GenericRepository<Course>())
        {
        }

        public CoursesController(IGenericRepository<Course> courses)
        {
            this.co = courses;
        }

        // GET: api/Courses
        public IHttpActionResult GetCourses()
        {
            var course = this.co.All().Select(CourseModel.FromCourse);
            return Ok(course);
        }

        // GET: api/Courses/5
        [ResponseType(typeof(CourseModel))]
        public IHttpActionResult GetCourse(Guid id)
        {
            var course = db.Courses.SearchFor(x => x.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourse(Guid id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.Id)
            {
                return BadRequest();
            }

            db.Context.Entry(course).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Courses
        [ResponseType(typeof(Course))]
        public IHttpActionResult PostCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(course);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CourseExists(course.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult DeleteCourse(Guid id)
        {
            var course = db.Courses.SearchFor(x => x.Id == id).FirstOrDefault();
            if (course == null)
            {
                return NotFound();
            }

            db.Context.Courses.Remove(course);
            db.SaveChanges();

            return Ok(course);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        ((StudentSystemDbContext)db).Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool CourseExists(Guid id)
        {
            return db.Courses.All().Where(x => x.Id == id).FirstOrDefault() != null;
        }
    }
}