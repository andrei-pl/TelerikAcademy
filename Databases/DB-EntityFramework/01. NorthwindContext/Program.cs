using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.NorthwindContext
{
   /// <summary>
   /// Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database
   /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities nw = new NorthwindEntities();

            var clients = from client in nw.Customers
                          select client.ContactName;

            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
        }
    }
}
