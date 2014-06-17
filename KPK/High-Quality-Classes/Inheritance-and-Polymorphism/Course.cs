namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Course
    {
        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name { get; set; }

        public string TeacherName { get; set; }

        public IList<string> Students { get; set; }

        protected string ToStringHelper(params KeyValuePair<string, string>[] otherInfo)
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            info["Name"] = this.Name;
            info["Teacher"] = this.TeacherName;
            info["Students"] = this.GetStudentsAsString();

            foreach (var item in otherInfo)
            {
                info[item.Key] = item.Value;
            }

            string infoToString = string.Join("; ", info.Where(item => !string.IsNullOrEmpty(item.Value)).Select(item => item.Key + "=" + item.Value));

            return string.Format("{0} {{ {1} }}", this.GetType().Name, infoToString);
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
