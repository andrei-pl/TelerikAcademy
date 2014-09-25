namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;
        private ICollection<Test> tests;
        private ICollection<Student> trainees;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
            this.tests = new HashSet<Test>();
            this.StudentInfo = new StudentInfo();
            this.Trainees = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public StudentStats studentStatus { get; set; }

        public StudentInfo StudentInfo { get; set; }

        public Student Assistant { get; set; }

        [InverseProperty("Assistant")]
        public ICollection<Student> Trainees
        {
            get { return this.trainees; }
            set { this.trainees = value; }
        }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public virtual ICollection<Test> Tests
        {
            get { return this.tests; }
            set { this.tests = value; }
        }
    }
}
