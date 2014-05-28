namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        public LocalCourse(string courseName, string teacherName = null, IList<string> students = null)
            : base(courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public string Lab { get; set; }

        public override string ToString()
        {
             return this.ToStringHelper(new KeyValuePair<string, string>("Lab", this.Lab));
        }
    }
}
