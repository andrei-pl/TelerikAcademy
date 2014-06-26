using System;

namespace _01.LeapOrNot
{
    //Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

    class LeapOrNot
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter year:");
            int year = int.Parse(Console.ReadLine());

            IsLeap(year);
        }

        private static void IsLeap(int year)
        {
            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine("The year {0} is leap", year);
            }
            else
            {
                Console.WriteLine("The year {0} is not leap", year);
            }
        }
    }
}
