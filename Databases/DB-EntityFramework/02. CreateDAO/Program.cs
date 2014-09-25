namespace _02.CreateDAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NorthwindDB;


    /// <summary>
    /// Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            DAO.InsertCustomer("SALCO", "Selo Ltd.", "Andy Mury", "Marketing Assistant", "31 Alexander Malinov", "Sofia city", "Sofia", "1000", "Bulgaria", "02 212-313", "02 212-313");

            DAO.ModifyCustomer("SALCO", "Selo Ltd.", "Andy Mury", "Sales Associate", "31 Alexander Malinov", "Sofia city", "Sofia", "1000", "Bulgaria", "02 212-313", "02 212-313");

            DAO.DeleteCustomer("SALCO");
            
            Console.WriteLine(DAO.PrintNCustomers(5));
        }
    }
}
