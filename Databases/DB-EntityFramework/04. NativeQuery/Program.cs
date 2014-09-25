namespace _04.NativeQuery
{
    using System;
    using System.Data.Entity;
    using NorthwindDB;

    /// <summary>
    /// Implement previous by using native SQL query and executing it through the DbContext.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string nativeQuery = @"SELECT c.ContactName from Customers c INNER JOIN Orders o ON o.CustomerID = c.CustomerID " +
                               "WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1});";

            object[] parameters = { 1997, "Canada" };

            using (var result = new NorthwindEntities())
            {
                var ContactNames = result.Database.SqlQuery<string>(nativeQuery, parameters);

                foreach (var name in ContactNames)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
