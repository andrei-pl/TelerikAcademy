using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>()
            {
                new Student("Pesho", "Mitev", 2),
                new Student("Maria", "Petrova", 1),
                new Student("Ivan", "Ivanov", 3),
                new Student("Joro", "Petkov", 4),
                new Student("Ivo", "Iliev", 2),
                new Student("Georgi", "Georgiev", 3),
                new Student("Misho", "Mitev", 4),
                new Student("Jana", "Nikolova", 1),
                new Student("Iva", "Ivanova", 2),
                new Student("Gergana", "Georgieva", 4),
            };

            var workers = new List<Worker>()
            {
                new Worker("Maria", "Ilieva", 800, 4),
                new Worker("Georgi", "Ignatov", 300, 8),
                new Worker("Stefka", "Kostadinova", 1200, 6),
                new Worker("Dancho", "Iovchev", 500, 2),
                new Worker("Bobi", "Mihailov", 300, 2),
                new Worker("Gala", "NaKafe", 450, 2),
                new Worker("Cvetelina", "Yaneva", 3000, 1),
                new Worker("Gloria", "Estefan", 2000, 4),
                new Worker("Dimitar", "Berbatov", 300000, 4),
                new Worker("Grigor", "Dimitrov", 5000, 4),
            };

            var sortedStudentsByGrade = students.OrderBy(x => x.Grade);
            var sortedWorkersByMoneyPerHour = workers.OrderByDescending(x => x.MoneyPerHour());

            foreach (var item in sortedStudentsByGrade)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in sortedWorkersByMoneyPerHour)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var mergedLists = sortedStudentsByGrade.Concat<dynamic>(sortedWorkersByMoneyPerHour);

            var sortBoth = mergedLists.OrderBy(x => x.FirstName);
            Console.WriteLine("Sort by First name:" + Environment.NewLine);
            foreach (var item in sortBoth)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
    }
}
