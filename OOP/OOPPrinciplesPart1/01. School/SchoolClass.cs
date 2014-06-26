using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public class SchoolClass : IComments
    {
        List<Teachers> teachers;
        List<Students> students;

        public string ClassID { get; set; }

        public SchoolClass(string ClassID)
        {
            this.ClassID = ClassID;
            this.teachers = new List<Teachers>();
            this.students = new List<Students>();
        }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
