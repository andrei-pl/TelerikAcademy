using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    class Program
    {
        static void Main(string[] args)
        {
            Discipline dis = new Discipline("Math", 10, 8);
            Discipline[] disciplines = new Discipline[1];
            disciplines[0] = dis;

            Person men = new Person("Pesho");

            Student ivan = new Student("Ivan", 13);
            Student[] students = new Student[1];
            students[0] = ivan;

            Teacher first = new Teacher("Joro");
            Teacher[] teachers = new Teacher[1];
            teachers[0] = first;

            ivan.AddComment("pesho");

            SchoolClass classA = new SchoolClass("8A");
            SchoolClass[] classes = new SchoolClass[1];

            School school = new School("Yane Sandanski");


            Console.WriteLine(ivan.Name);
            Console.WriteLine(men.Name);
        }
    }
}
