namespace _01.Student
{
    using System;
    using System.Text;

    /// <summary>
    /// Gets
    /// </summary>
    public class Student : ICloneable, IComparable<Student>
    {
        //// 1. Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, 
        //// mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, universities and faculties. 
        //// Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

        /// <summary>
        /// Gets
        /// </summary>
        /// <param name="firstName"></param> 
        /// <param name="middlename"></param> 
        /// <param name="LastName"></param> 
        /// <param name="ssn"></param>  
        /// <param name="address"></param> 
        /// <param name="mobile"></param> 
        /// <param name="mail"></param> 
        /// <param name="course"></param> 
        /// <param name="speciality"></param> 
        /// <param name="university"></param> 
        /// <param name="faculty"></param> 
        public Student(string firstName, string middlename, string lastName, string ssn, string address = "", string mobile = "", string mail = "", string course = "", Specialty speciality = Specialty.Informatics, string university = "", string faculty = "")
        {
            this.FirstName = firstName;
            this.MiddleName = middlename;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.Mobile = mobile;
            this.Mail = mail;
            this.Course = course;
            this.Speciality = speciality;
            this.University = university;
            this.Faculty = faculty;
        }
             
        /// <summary>
        /// Gets
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets
        /// </summary>
        public string Address { get; private set; }
       
        /// <summary>
        /// Gets
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// Gets
        /// </summary>
        public string Mobile { get; private set; }

        /// <summary>
        /// Gets
        /// </summary>
        public string Mail { get; private set; }

        /// <summary>
        /// Gets
        /// </summary>
        public string Course { get; private set; }

        /// <summary>
        /// Gets
        /// </summary>
        public Specialty Speciality { get; set; }

        /// <summary>
        /// Gets
        /// </summary>
        public string University { get; private set; }
  
        /// <summary>
        /// Gets
        /// </summary>
        public string Faculty { get; private set; }
        
        /// <summary>
        /// Gets
        /// </summary>
        /// <param name="student1"></param>
        /// <param name="student2"></param>
        /// <returns></returns>
        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        /// <summary>
        /// Gets
        /// </summary>
        /// <param name="student1"></param>
        /// <param name="student2"></param>
        /// <returns></returns>
        public static bool operator !=(Student student1, Student student2)
        {
            return !Student.Equals(student1, student2);
        }

        /// <summary>
        /// Gets
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public override bool Equals(object student)
        {
            return this.SSN == (student as Student).SSN;
        }

        /// <summary>
        /// Gets
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.SSN.GetHashCode();
        }

        /// <summary>
        /// Gets
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine(base.ToString());

            if(!string.IsNullOrEmpty(this.FirstName))
            {
                info.AppendLine("First name: " + this.FirstName);
            }

            if(!string.IsNullOrEmpty(this.MiddleName))
            {
                info.AppendLine("Middle name: " + this.MiddleName);
            }

            if(!string.IsNullOrEmpty(this.LastName))
            {
                info.AppendLine("Last name: " + this.LastName);
            }

            if(!string.IsNullOrEmpty(this.SSN))
            {
                info.AppendLine("SSN: " + this.SSN);
            }

            if (!string.IsNullOrEmpty(this.Address))
            {
                info.AppendLine("Address: " + this.Address);
            }

            if (!string.IsNullOrEmpty(this.Mail))
            {
                info.AppendLine("Email: " + this.Mail);
            }

            if (!string.IsNullOrEmpty(this.Mobile))
            {
                info.AppendLine("Phone: " + this.Mobile);
            }

            if (!string.IsNullOrEmpty(this.Course))
            {
                info.AppendLine("Course Specialty: " + this.Course);
            }

            info.AppendLine("Course Specialty: " + this.Speciality.ToString());

            if (!string.IsNullOrEmpty(this.University))
            {
                info.AppendLine("University: " + this.University);
            }

            if (!string.IsNullOrEmpty(this.Faculty))
            {
                info.AppendLine("Faculty: " + this.Faculty);
            }

            return info.ToString().TrimEnd();
        }

        //// 2. Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student.
        
        /// <summary>
        /// Gets
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, this.Mobile, this.Mail, this.Course, this.Speciality, this.University, this.Faculty);
        }

        //// 3. Implement the  IComparable<Student> interface to compare students by names 
        //// (as first criteria, in lexicographic order) and by social security number (as second criteria, in increasing order).

        /// <summary>
        /// Gets
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Student other)
        {
            if (Student.Equals(this, other))
            {
                return 0;
            }

            return (this.FirstName + this.MiddleName + this.LastName + this.SSN).CompareTo(other.FirstName + other.MiddleName + other.LastName + other.SSN);
        }
    }
}