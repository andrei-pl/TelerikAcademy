namespace _05.SalesByRegion
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using NorthwindDB;

    /// <summary>
    /// Write a method that finds all the sales by specified region and period (start / end dates).
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            FindAllSalesByDateRange("RJ", 1996, 1996);
        }

        static void FindAllSalesByDateRange(string region, int startDate, int endDate)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var sales = from ord in db.Orders
                            join ordDetails in db.Order_Details
                            on ord.OrderID equals ordDetails.OrderID
                            where (ord.ShipRegion == region && ord.OrderDate.Value.Year == startDate && ord.ShippedDate.Value.Year == endDate)
                            select new
                            {
                                Quantity = ordDetails.Quantity,
                                Region = ord.ShipRegion,
                                Country = ord.ShipCountry
                            };

                foreach (var sale in sales)
                {
                    Console.WriteLine("Ship Region: {0}, Ship Country: {1}, Order Quantity: {2}",
                                        sale.Region, sale.Country, sale.Quantity);
                }
            }
        }
    }
}
