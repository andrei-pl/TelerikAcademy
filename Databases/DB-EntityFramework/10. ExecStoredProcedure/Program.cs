namespace _10.ExecStoredProcedure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NorthwindDB;

    /// <summary>
    /// Create a stored procedures in the Northwind database for finding the total incomes for given supplier name 
    /// and period (start date, end date). Implement a C# method that calls the stored procedure and returns the retuned record set.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities db = new NorthwindEntities();

            string companyName = "Exotic Liquids";
            var startDate = DateTime.Parse("1980.01.21");
            var endDate = DateTime.Parse("1999.01.22");

            var income = db.usp_GetTotalIncome(companyName, startDate, endDate);

            Console.WriteLine("Using foreach:");
            foreach (var item in income)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Without using foreach:");
            Console.WriteLine(income);
        }
    }
}
