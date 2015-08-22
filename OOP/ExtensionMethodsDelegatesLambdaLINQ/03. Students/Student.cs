using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Students
{
    class Student
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            private set
            {
                foreach (var ch in value)
                {
                    if (!Char.IsLetter(ch))
                    {
                        break;
                    }
                    firstName = value;
                }
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            private set
            {
                foreach (var ch in value)
                {
                    if (!Char.IsLetter(ch))
                    {
                        Console.WriteLine("Invalid name!");
                        break;
                    }
                    lastName = value;
                }
            }
        }

        private byte age;
        public byte Age
        {
            get { return age; }
            private set
            {
                if (value < 0 || value > 120)
                {
                    Console.WriteLine("Invalid Age!");
                }
                else
                {
                    age = value;
                }
            }
        }
        public Student(string firstName, string lastName, byte age, List<int> marks)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            this.marks = new List<int>(marks);
        }

        //09. Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. 
        //Create a List<Student> with sample students. Select only the students that are from group number 2. Use LINQ query. 
        //Order the students by FirstName.

        private string fN;
        public string FN
        {
            get { return fN; }
            set
            {
                fN = value;
            }
        }

        private string tel;
        public string Tel
        {
            get { return tel; }
            set
            {
                foreach (var ch in value)
                {
                    if(!Char.IsDigit(ch))
                    throw new FormatException("Invalid number!");
                }
                tel = value;
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }

        private int groupNumber;
        public int GroupNumber
        {
            get { return groupNumber; }
            set
            {
                groupNumber = value;
            }
        }

        private List<int> marks;
        public List<int> Marks
        {
            get { return marks; }
        }

        public int CountMarks(int mark)
        {
            int result = 0;
            foreach (var item in Marks)
            {
                if (mark == item)
                {
                    result++;
                }
            }
            return result;
        }

        //16. * Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. 
        //Extract all students from "Mathematics" department. Use the Join operator.

        public Group StudentGroup { get; set; }
    }
}
