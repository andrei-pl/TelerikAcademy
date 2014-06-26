using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public class Teachers : Person, IComments
    {
        public List<Disciplines> Discplines { get; set; }
               
        public Teachers(string name) : base(name)
        {
            this.Discplines = new List<Disciplines>();
            this.Name = name;
        }
        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
