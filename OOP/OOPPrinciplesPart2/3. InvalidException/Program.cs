using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.InvalidException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number between 1 and 100: ");
            int number = int.Parse(Console.ReadLine());

            if (number > 100 || number < 1)
            {
                throw new InvalidRangeException<int>(1, 100);
            }

            Console.WriteLine("Please enter date: ");

            DateTime date = DateTime.Parse(Console.ReadLine());
            DateTime end = new DateTime(2013, 12, 31);
            DateTime start = new DateTime(1980, 1, 1);

            if (date > end || date < start)
            {
                string msg = string.Format("The date is not in the right range.");
                throw new InvalidRangeException<DateTime>(msg, start, end);
            }
        }
    }
}
