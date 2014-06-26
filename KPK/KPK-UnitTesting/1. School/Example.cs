namespace School
{
    using System;
    using System.Linq;

    // Write three classes: Student, Course and School. Students should have name and unique number (inside the entire School). 
    //Name can not be empty and the unique number is between 10000 and 99999. 
    //Each course contains a set of students. Students in a course should be less than 30 and can join and leave courses.

    public class Example
    {
        static void Main()
        {
            School school = new School("School");
            Course course = new Course("Course");
            Student student = new Student("John", 10110);
        }
    }
}