using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public class Teacher : Person, IComments
    {
        public List<Discipline> Discplines { get; set; }
               
        public Teacher(string name) : base(name)
        {
            this.Discplines = new List<Discipline>();
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
