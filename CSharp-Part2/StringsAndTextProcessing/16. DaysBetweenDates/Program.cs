using System;
using System.Globalization;

namespace _16.DaysBetweenDates
{
    //Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
    //Enter the first date: 27.02.2006 Enter the second date: 3.03.2006 Distance: 4 days

    class Program
    {
        static void Main(string[] args)
        {
            DateTime firstDate = new DateTime(2006, 02, 27);
            DateTime secondDate = new DateTime(2006, 03, 3);
            string format = "d.MM.yyyy";
            string daysFormat = "dd";

            TimeSpan distance = firstDate - secondDate;

            Console.WriteLine("Distance between {0} and {1} is: {2}", firstDate.ToString(format, CultureInfo.InvariantCulture),
                secondDate.ToString(format, CultureInfo.InvariantCulture), distance.ToString(daysFormat, CultureInfo.InvariantCulture));
        }
    }
}
