namespace _09.PlaceNewOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NorthwindDB;

    /// <summary>
    /// Create a method that places a new order in the Northwind database. 
    /// The order should contain several order items. Use transaction to ensure the data consistency.
    /// </summary>
    class Program
    {
        static NorthwindEntities db = new NorthwindEntities();

        static void Main(string[] args)
        {
            //<productID, quantity>
            Tuple<int, int> firstProduct = new Tuple<int, int>(1, 999);
            Tuple<int, int> secondProduct = new Tuple<int, int>(3, 999);
            InsertOrder("CHOPS", DateTime.Now, "Lukovit", firstProduct, secondProduct);

            Console.WriteLine("Order inserted!");
            var orders = (from ord in db.Orders
                          join det in db.Order_Details
                          on ord.OrderID equals det.OrderID
                          where det.Quantity > 900
                          select ord).Distinct();

            foreach (var order in orders)
            {
                Console.WriteLine("ID: {0}, OrderAddress: {1}, OrderDate: {2}",order.CustomerID, order.ShipAddress, order.OrderDate);
            }
        }

        static void InsertOrder(string customerID, DateTime orderDate, string address, params Tuple<int, int>[] products)
        {
            Order newOrder = new Order()
            {
                CustomerID = customerID,
                OrderDate = orderDate,
                ShipAddress = address
            };

            var insertedOrder = db.Orders.Add(newOrder);

            foreach (var prod in products)
            {
                Order_Detail newDetail = new Order_Detail()
                {
                    OrderID = insertedOrder.OrderID,
                    ProductID = prod.Item1,
                    Quantity = (short)prod.Item2
                };

                db.Order_Details.Add(newDetail);
            }

            db.SaveChanges();
        }
    }
}
