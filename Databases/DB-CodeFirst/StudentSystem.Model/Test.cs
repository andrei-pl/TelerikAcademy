namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Exam")]
    public class Test
    {
        private ICollection<Student> students;

        public Test()
        {
            this.Id = Guid.NewGuid();
            this.students = new HashSet<Student>();
        }

        [ForeignKey("Course")]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
