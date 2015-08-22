using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public class SchoolClass : IComments
    {
        List<Teacher> teachers;
        List<Student> students;

        public string ClassID { get; set; }

        public SchoolClass(string ClassID)
        {
            this.ClassID = ClassID;
            this.teachers = new List<Teacher>();
            this.students = new List<Student>();
            this.Comments = new List<string>();
        }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
