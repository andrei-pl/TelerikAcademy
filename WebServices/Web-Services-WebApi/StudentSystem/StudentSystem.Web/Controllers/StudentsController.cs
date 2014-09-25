namespace StudentSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Data.Repositories;
    using StudentSystem.Models;
    using StudentSystem.Web.Models;

    public class StudentsController : ApiController
    {
        private IGenericRepository<Student> st;
        private StudentsSystemData db = new StudentsSystemData();

        public StudentsController()
            : this(new GenericRepository<Student>())
        {
        }

        public StudentsController(IGenericRepository<Student> students)
        {
            this.st = students;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var student = this.st.All().Select(StudentModel.FromStudent);

            return Ok(student);
        }

        [HttpGet]
        public IHttpActionResult GetByID(int id)
        {
            if(!this.ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            var studentModel = this.st.All().Select(StudentModel.FromStudent).Where(x => x.Id == id);

            return Ok(studentModel);
        }

        [HttpGet]
        public IHttpActionResult GetByName(string name)
        {
            if(!this.ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            var studentModel = this.st.All().Select(StudentModel.FromStudent).Where(x => x.FirstName == name);

            return Ok(studentModel);
        }

        [HttpGet]
        public IQueryable<StudentModel> FilterStudents()
        {
            var students = this.st.All().Select(StudentModel.FromStudent);

            return students.AsQueryable<StudentModel>();
        }

        [HttpPost]
        public IHttpActionResult AddStudent(Student student)
        {
            if(!this.ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            db.Students.Add(student);
            db.SaveChanges();

            return Ok("Student successfully added.");
        }

        [HttpPut]
        public HttpResponseMessage ChangeById(int id, StudentModel student)
        {
            var students = this.st.All().Select(StudentModel.FromStudent).Where(x => x.Id == id).FirstOrDefault();
            var studentFromDb = this.st.All().Where(x => x.StudentIdentification == id).FirstOrDefault();

            if (students == null)
            {
                //return Request.CreateResponse(HttpStatusCode.BadRequest, "The student does not exist.");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The student does not exist.");
            }

            studentFromDb.FirstName = student.FirstName;
            studentFromDb.LastName = student.LastName;
            studentFromDb.Level = student.Level;
            studentFromDb.Homeworks = student.Homeworks;
            studentFromDb.Courses = student.Courses;

            db.Students.Update(studentFromDb);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.BadRequest, "The student successfully changed.");
        }

        [HttpDelete]
        public HttpResponseMessage DeleteStudent(int id)
        {
            var studentFromDb = this.st.All().Where(x => x.StudentIdentification == id).FirstOrDefault();

            if (studentFromDb == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "The student does not exist.");
            }
            else
            {
                this.db.Students.Delete(studentFromDb);
                this.db.Students.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Student deleted.");
            }
        }
    }
}
