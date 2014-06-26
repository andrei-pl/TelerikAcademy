using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Students
{
    //16. * Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. 
    //Extract all students from "Mathematics" department. Use the Join operator.

    class Group
    {
        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }

        private int groupNumber;
        public int GroupNumber
        {
            get { return this.groupNumber; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Group number can't be negative number!");
                }
                this.groupNumber = value;
            }
        }

        public string DepartmentName { get; set; }
    }
}
