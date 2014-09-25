namespace _02.CreateDAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using NorthwindDB;

    public static class DAO
    {
        static NorthwindEntities db = new NorthwindEntities();
        public static bool InsertCustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            Customer newCustomer = new Customer
            {
                CustomerID = customerId,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };

            db.Customers.Add(newCustomer);

            if (db.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }

        public static bool ModifyCustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            var foundCustomer = (from customer in db.Customers
                                        where customerId == customer.CustomerID
                                        select customer).First();

            foundCustomer.CompanyName = companyName;
            foundCustomer.ContactName = contactName;
            foundCustomer.ContactTitle = contactTitle;
            foundCustomer.Address = address;
            foundCustomer.City = city;
            foundCustomer.Region = region;
            foundCustomer.PostalCode = postalCode;
            foundCustomer.Country = country;
            foundCustomer.Phone = phone;
            foundCustomer.Fax = fax;

            if (db.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }

        public static bool DeleteCustomer(string id)
        {
            Customer deleteCustomer = (from customer in db.Customers
                                      where customer.CustomerID == id
                                      select customer).First();

            db.Customers.Remove(deleteCustomer);

            if (db.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }

        public static StringBuilder PrintNCustomers (int n)
        {
            StringBuilder result = new StringBuilder();

            foreach (var customer in (from c in db.Customers select c).Take(n))
            {
                result.Append(customer.ContactName);
                result.Append(Environment.NewLine);
            }

            return result;
        }
    }
}
