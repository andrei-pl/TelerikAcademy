using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompaniInfo
{
    class Program
    {
        //A company has name, address, phone number, fax number, web site and manager. 
        //The manager has first name, last name, age and a phone number.
        //Write a program that reads the information about a company and its manager and prints them on the console.

        static void Main(string[] args)
        {                                                //collecting information
            Console.Write("Enter name of the company: ");
            string nameCompany = Console.ReadLine();
            Console.Write("Enter address of the company: ");
            string addressCompany = Console.ReadLine();
            Console.Write("Enter phone number of the company: ");
            string phoneCompany = Console.ReadLine();                      //it's string because it can contain "+" simbol or "0" at the beginig
            Console.Write("Enter fax number of the company: ");
            string faxCompany = Console.ReadLine();
            Console.Write("Enter web site of the company: ");
            string webSiteCompany = Console.ReadLine();
            Console.Write("Enter first name of the company's manager: ");
            string firstNameManagerCompany = Console.ReadLine();
            Console.Write("Enter last name of the company's manager: ");
            string lastNameManagerCompany = Console.ReadLine();
            Console.Write("Enter age of the company's manager: ");
            byte ageManagerCompany = Byte.Parse(Console.ReadLine());
            Console.Write("Enter phone of the company's manager: ");
            string phoneManagerCompany = Console.ReadLine();

            Console.Clear();                           //Printing all information

            Console.WriteLine();
            Console.WriteLine("Information about the company and its manager!");
            Console.WriteLine();
            Console.WriteLine("Company name: " + nameCompany);
            Console.WriteLine("Address: " + addressCompany);
            Console.WriteLine("Phone: " + phoneCompany);
            Console.WriteLine("Fax: " + faxCompany);
            Console.WriteLine("Site: " + webSiteCompany);
            Console.WriteLine();
            Console.WriteLine("Manager Full Name: " + firstNameManagerCompany + " " + lastNameManagerCompany);
            Console.WriteLine("Age: " + ageManagerCompany);
            Console.WriteLine("Phone: " + phoneManagerCompany);
        }
    }
}
