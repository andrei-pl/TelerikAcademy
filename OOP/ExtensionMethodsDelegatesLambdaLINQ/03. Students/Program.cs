using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Students
{
    //03. Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
    //Use LINQ query operators.

    class Program
    {
        static void Main(string[] args)
        {
            Students[] students = { 
                                      new Students("Joro", "Ivanov", 17, new List<int>{2,6}),  
                                      new Students("Maria", "Petrova", 25, new List<int>{3,4}),  
                                      new Students("Ivan", "Ivanov", 31, new List<int>{6,5}),  
                                      new Students("Pesho", "Mitev", 22, new List<int>{4,6}),  
                                      new Students("Niki", "Iliev", 24, new List<int>{2,2}), 
                                      new Students("Niki", "Nikolov", 19, new List<int>{3,3}),
                                  };

            var alphabetStudents = from s in students
                                   where (s.FirstName.ToLower().CompareTo(s.LastName.ToLower()) < 0)
                                   select s;

            Console.WriteLine("Students whose first name is before its last name alphabetically:");
            PrintStudents(alphabetStudents);

            //04. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

            var studentsByAge = from s in students
                                where (s.Age > 17 && s.Age < 25)
                                select s;
            Console.WriteLine("Students by age 18-24:");

            PrintStudents(studentsByAge);

            //05. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students 
            //by first name and last name in descending order. Rewrite the same with LINQ.

            Console.WriteLine();
            Console.WriteLine("Students ordered by descending order!");
            var orderedStudents = from s in students
                                  orderby s.FirstName descending, s.LastName descending
                                  select s;

            PrintStudents(orderedStudents);

            var orderedStudents2 = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);

            Console.WriteLine("Students ordered by descending order (Variant 2)!");

            PrintStudents(orderedStudents2);

            //09. Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. 
            //Create a List<Student> with sample students. Select only the students that are from group number 2. Use LINQ query. 
            //Order the students by FirstName.

            var studentsGroup = new List<Students>(students);

            studentsGroup[0].GroupNumber = 1; studentsGroup[0].Email = "student1@abv.bg"; studentsGroup[0].Tel = "027776665"; studentsGroup[0].FN = "55040621";
            studentsGroup[1].GroupNumber = 2; studentsGroup[1].Email = "student2@gmail.com"; studentsGroup[1].Tel = "032555666"; studentsGroup[1].FN = "56040621";
            studentsGroup[2].GroupNumber = 2; studentsGroup[2].Email = "student3@abv.bg"; studentsGroup[2].Tel = "039394545"; studentsGroup[2].FN = "55040521";
            studentsGroup[3].GroupNumber = 1; studentsGroup[3].Email = "student4@abv.bg"; studentsGroup[3].Tel = "054515616"; studentsGroup[3].FN = "55040622";
            studentsGroup[4].GroupNumber = 2; studentsGroup[4].Email = "student5@gmail.com"; studentsGroup[4].Tel = "024561231"; studentsGroup[4].FN = "55040721";
            studentsGroup[5].GroupNumber = 1; studentsGroup[5].Email = "student6@gmail.com"; studentsGroup[5].Tel = "032777666"; studentsGroup[5].FN = "55041221";

            var selectedStudents = from student in studentsGroup
                                   where student.GroupNumber == 2
                                   orderby student.FirstName
                                   select student;

            Console.WriteLine("Students in group 2:");

            PrintStudents(selectedStudents);

            //10. Implement the previous using the same query expressed with extension methods.

            var selectedStudents2 = studentsGroup.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);
            
            Console.WriteLine("Students in group 2 (variant 2):");

            PrintStudents(selectedStudents2);

            //11. Extract all students that have email in abv.bg. Use string methods and LINQ.

            var studentsByEmail = from student in studentsGroup
                                  where student.Email.EndsWith("@abv.bg")
                                  select student;
           
            Console.WriteLine("Students by e-mail in abv.bg:");

            PrintStudents(studentsByEmail);

            //12. Extract all students with phones in Sofia. Use LINQ.

            var studentsInSofia = from student in studentsGroup
                                  where student.Tel.StartsWith("02")
                                  select student;
           
            Console.WriteLine("Students by phone in Sofia:");

            PrintStudents(studentsInSofia);

            //13. Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.

            var studentsWithExcellentMark = from student in students
                                            where student.Marks.Contains(6)
                                            select new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks };

            Console.WriteLine("Students that have at least one mark Excellent (6):");
           
            foreach (var item in studentsWithExcellentMark)
            {
                string mark = String.Empty;
                foreach (var value in item.Marks)
                {
                    mark += value + " ";
                }
                Console.WriteLine(item.FullName + " " + mark);
            }

            Console.WriteLine();

            //14. Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.

            var studentsWithTwoMarks = studentsGroup.Where(x => x.CountMarks(2) == 2);

            Console.WriteLine("Students with exactly  two marks \"2\":");

            PrintStudents(studentsWithTwoMarks);

            //15. Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).

            var studentsFrom2006 = from student in studentsGroup
                                   where student.FN.Substring(4, 2) == "06"
                                   select student;

            Console.WriteLine("Students from 2006:");

            PrintStudents(studentsFrom2006);

            //16. * Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. 
            //Extract all students from "Mathematics" department. Use the Join operator.

            studentsGroup[0].StudentGroup = new Group(2, "Mathematics");
            studentsGroup[1].StudentGroup = new Group(1, "Physics");
            studentsGroup[2].StudentGroup = new Group(2, "Mathematics");
            studentsGroup[3].StudentGroup = new Group(1, "Mathematics");
            studentsGroup[4].StudentGroup = new Group(2, "Physics");
            studentsGroup[5].StudentGroup = new Group(1, "Physics");

            var studentsInMath = from student in studentsGroup
                                 where student.StudentGroup.DepartmentName == "Mathematics"
                                 select new { FullName = student.FirstName + " " + student.LastName };
           
            Console.WriteLine("Students from Mathematics department:");
            Console.WriteLine(String.Join(Environment.NewLine, studentsInMath));
        }

        private static void PrintStudents(IEnumerable<Students> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
            Console.WriteLine();
        }
    }
}
