using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.Web.Models
{
    public class CourseModel
    {
        public CourseModel()
        {
            this.Students = new HashSet<Student>();
            this.Homeworks = new HashSet<Homework>();
        }

        public static Expression<Func<Course, CourseModel>> FromCourse
        {
            get
            {
                return x => new CourseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Students = x.Students,
                    Homeworks = x.Homeworks,
                };
            }
        }

        public Guid Id { get; set; }

        [Column("CourseName")]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}