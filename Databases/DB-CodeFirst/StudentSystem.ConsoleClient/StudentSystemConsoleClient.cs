namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Model;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Data.Repositories;

    class StudentSystemConsoleClient
    {
        static void Main()
        {

            var data = new StudentSystemData();

            data.Students.Add(
                new Student
                {
                    FirstName = "Bai Ivan",
                    LastName = "Ivanov",
                    Age = 63,
                    studentStatus = StudentStats.OnLine
                });

            data.Students.SaveChanges();
            
            foreach (var student in data.Students.All())
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " -> " + student.Age + " years");
            }

            //db.Database.Initialize(true);

            //var student = new Student
            //{
            //    Age = 32,
            //    FirstName = "Gosho",
            //    LastName = "Peshov",
            //    studentStatus = StudentStats.OnLine
            //};

            //student.Courses.Add(new Course
            //{
            //    Name = "Databases rocks"
            //});

            //db.Students.Add(student);
            //db.SaveChanges();

            //var savedStudents = db.Students.First();
            //Console.WriteLine(savedStudents.FirstName + " " + savedStudents.LastName + " - " + savedStudents.Age + " years");
        }
    }
}
