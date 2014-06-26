using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecord
{
    class EmployeeRecord
    {
        //A marketing firm wants to keep record of its employees. Each record would have the following characteristics – 
        //first name, family name, age, gender (m or f), ID number, unique employee number (27560000 to 27569999). 
        //Declare the variables needed to keep the information for a single employee using appropriate data types and descriptive names.

        static void Main(string[] args)
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter famil name: ");
            string familyName = Console.ReadLine();

            Console.Write("Enter age: ");
            byte age = Byte.Parse(Console.ReadLine());

            Console.Write("Gender: ");
            char gender = Char.Parse(Console.ReadLine());

            Console.Write("ID: ");
            int idNumber = Int32.Parse(Console.ReadLine());

            Console.Write("Enter unique employee number: ");
            ushort employeeNumber = ushort.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("{0} {1} \nAge: {2} \nGender: {3} \nID: {4} \nEmployee number: {5}", firstName, familyName, age, gender,idNumber, 27560000 + employeeNumber);
        }
    }
}
