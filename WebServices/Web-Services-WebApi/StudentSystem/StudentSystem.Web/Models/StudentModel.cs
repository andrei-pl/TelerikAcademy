namespace StudentSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    using StudentSystem.Models;
    using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

    public class StudentModel
    {
        public StudentModel()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
        }
        
        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return x => new StudentModel
                {
                    Id = x.StudentIdentification,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Courses = x.Courses,
                    Homeworks = x.Homeworks,
                    Level = x.Level,
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Level { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}