using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public class School
    {
        public string SchoolName { get; set; }
    
        List<SchoolClass> classes;

        public School(string schoolName)
        {
            this.classes = new List<SchoolClass>();
            this.SchoolName = schoolName;
        }
    }
}
