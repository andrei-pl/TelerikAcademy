using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.GroupStudents
{
    class Program
    {
        //18. Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.

        //19. Rewrite the previous using extension methods.

        static void Main(string[] args)
        {
            var students = new Student[]
            {
                new Student("Joro", "Ivanov", "Physicians"),
                new Student("Maria", "Petrova", "Mathematicians"),
                new Student("Ivan", "Ivanov", "Mathematicians"),
                new Student("Pesho", "Mitev", "Programmers"),
                new Student("Niki", "Iliev", "Mathematicians"),
                new Student("Niki", "Nikolov", "Programmers")
            };

            GroupWithLinq(students);

            GroupWithLambda(students);
        }

        private static void GroupWithLinq(Student[] students)
        {
            var groupStudents = from student in students
                                group student by student.GroupName into newGroup
                                orderby newGroup.Key
                                select newGroup;

            PrintStudentsByGroup(groupStudents);
        }

        private static void GroupWithLambda(Student[] students)
        {
            var groupStudents = students.GroupBy(x => x.GroupName).OrderBy(x => x.Key);

            PrintStudentsByGroup(groupStudents);
        }

        private static void PrintStudentsByGroup(IOrderedEnumerable<IGrouping<string, Student>> groupStudents)
        {
            foreach (var currentGroup in groupStudents)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(currentGroup.Key);
                Console.ResetColor();

                foreach (var student in currentGroup)
                {
                    Console.WriteLine(student.FirstName + " " + student.LastName);
                }
                Console.WriteLine();
            }
        }
    }
}
