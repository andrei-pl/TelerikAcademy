namespace _1.SelectEmploeesWithInclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using System.Diagnostics;

    class Program
    {
        static TelerikAcademy db = new TelerikAcademy();
        static Stopwatch timer;
        static void Main(string[] args)
        {
            // 1. Using Entity Framework write a SQL query to select all employees from the Telerik Academy database and later print their name, department and town. 
            // Try the both variants: with and without .Include(…). Compare the number of executed SQL statements and the performance.

            //Test everything one by one, because of the connection to the database, although I do not see much difference.

            TimeSpan first;
            TimeSpan second;
            TimeSpan third;
            timer = new Stopwatch();
            
            timer.Start();
            GetInfoWithInclude();
            first = timer.Elapsed;

            timer.Restart();
            GetInfoWithLinq();
            second = timer.Elapsed;

            timer.Restart();
            GetInfoWithoutInclude();
            third = timer.Elapsed;
            
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);

            // 2. Using Entity Framework write a query that selects all employees from the Telerik Academy database, then invokes ToList(), 
            //then selects their addresses, then invokes ToList(), then selects their towns, then invokes ToList() 
            //and finally checks whether the town is "Sofia". Rewrite the same in more optimized way and compare the performance.
            
            timer.Restart();
            SelectEmployeesUsingToListEverywhere();
            Console.WriteLine(timer.Elapsed);

            timer.Restart();
            SelectEmployeesUsingToListOptimized();
            Console.WriteLine(timer.Elapsed);

        }

        private static void SelectEmployeesUsingToListOptimized()
        {
            var allEmployeesOptimized = db.Employees
                                               .Select(e => e.Address)
                                               .Select(e => e.Town)
                                               .Where(e => e.Name == "Sofia").ToList();
        }

        private static void SelectEmployeesUsingToListEverywhere()
        {
            var allEmployees = db.Employees.ToList()
                                      .Select(e => e.Address).ToList()
                                      .Select(e => e.Town).ToList()
                                      .Where(e => e.Name == "Sofia");
        }

        static void GetInfoWithoutInclude()
        {
            foreach (var employee in db.Employees)
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("{0}", employee.Department.Name);
                Console.WriteLine("{0}", employee.Address.Town.Name);
                Console.WriteLine();
            }
            Console.WriteLine(db.Employees.Count());
        }

        static void GetInfoWithInclude()
        {
            foreach (var employee in db.Employees.Include("Address.Town").Include("Department"))
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("{0}", employee.Department.Name);
                Console.WriteLine("{0}", employee.Address.Town.Name);
                Console.WriteLine();
            }
        }

        static void GetInfoWithLinq()
        {
            var employees = db.Employees.Select(employee =>
                new
                {
                    Name = employee.FirstName + " " + employee.LastName,
                    DepartmentName = employee.Department.Name,
                    City = employee.Address.Town.Name
                });

            foreach (var employee in employees)
            {
                Console.WriteLine("{0}", employee.Name);
                Console.WriteLine("{0}", employee.DepartmentName);
                Console.WriteLine("{0}", employee.City);
                Console.WriteLine();
            }
        }
    }
}
