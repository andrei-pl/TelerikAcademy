namespace _03.CustomerOrders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NorthwindDB;


    /// <summary>
    /// Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities db = new NorthwindEntities();

            var customers = GetCustomers(db);

            foreach (var item in customers)
            {
                Console.WriteLine(item);
            }


        }

        static IEnumerable<string> GetCustomers(NorthwindEntities db)
        {
            var customers = (from customer in db.Customers
                             join ord in db.Orders on customer.CustomerID equals ord.CustomerID
                             where ord.ShipCountry == "Canada" && ord.OrderDate.Value.Year == 1997
                             select new
                              {
                                  CustomerID = customer.CustomerID,
                                  ContactName = customer.ContactName,
                                  OrderID = ord.OrderID,
                                  OrderDate = ord.OrderDate
                              }).Distinct();

            foreach (var item in customers)
            {
                yield return string.Format("{0} {1} - order ID:{2}, order Date: {3}",
                    item.CustomerID, item.ContactName, item.OrderID, item.OrderDate.Value.ToShortDateString());
            }
        }
    }
}
