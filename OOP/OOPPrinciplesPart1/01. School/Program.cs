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
            Disciplines dis = new Disciplines("Math", 10, 8);
            Disciplines[] disciplines = new Disciplines[1];
            disciplines[0] = dis;

            Person men = new Person("Pesho");

            Students ivan = new Students("Ivan", 13);
            Students[] students = new Students[1];
            students[0] = ivan;

            Teachers first = new Teachers("Joro");
            Teachers[] teachers = new Teachers[1];
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
