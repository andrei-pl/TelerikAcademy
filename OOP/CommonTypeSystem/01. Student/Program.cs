namespace _01.Student
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = {
            new Student("Ivan", "Ivanov", "Ivanov", "1"),
            new Student("Gosho", "Goshev", "Goshev", "2"),
            new Student("Pesho", "Peshov", "Peshov", "3"),
            new Student("Viara", "Nadejdeva", "Lubenova", "4")
        };

            // makes check with equals
            Console.WriteLine("student1 is equals to student2 = {0}",students[0].Equals(students[1]));
            // makes check with !=
            if (students[0] != students[1])
            {
                Console.WriteLine("{0} != {1}", students[0], students[1]);
            }

            // makes second student to be equal to first
            students[1].FirstName = "Ivan";

            // makes again two types check
            Console.WriteLine("student1 is equals to student2 = {0}", students[0].Equals(students[1]));
            if (students[0] == students[1])
            {
                Console.WriteLine("{0} == {1}", students[0], students[1]);
            }

            // checks if are Clone method is deep
            students[2] = (Student)students[0].Clone();
            students[2].FirstName = "Mitko";
            Console.WriteLine(students[0].FirstName);
            students[2].Speciality = Specialty.Marketing;
            Console.WriteLine(students[0].Speciality);

            // test compare method
        Array.Sort(students);

        Console.WriteLine(String.Join<Student>(Environment.NewLine + Environment.NewLine, students));
        }
    }
}
