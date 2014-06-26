using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.GroupStudents
{
    class Student
    {
        public Student(string firstName, string lastName, string groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GroupName = groupName;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string GroupName { get; private set; }
    }
}
