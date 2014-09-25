namespace StudentSystem.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class StudentInfo
    {
        [Column("Faculty Number")]                  // I can't see the logic for StudentsInCourses, so that's why I didn't implement it.
        public string Number { get; set; }

        [Column("E-Mail")]
        public string Email { get; set; }

        [Column("Facebook Account")]
        public string Facebook { get; set; }

        [Column("Skype Account")]
        public string Skype { get; set; }
    }
}
