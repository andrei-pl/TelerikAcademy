using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public class Student : Person, IComments
    {
        public int ClassNumber { get; set; }

        public Student(string name, int classNumber) : base(name)
        {
            this.ClassNumber = classNumber;
            this.Name = name;
            this.Comments = new List<string>();
        }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
