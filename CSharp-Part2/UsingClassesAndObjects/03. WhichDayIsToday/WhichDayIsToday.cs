using System;

namespace _03.WhichDayIsToday
{
    //Write a program that prints to the console which day of the week is today. Use System.DateTime.

    class WhichDayIsToday
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Today is " + DateTime.Today.DayOfWeek);
        }
    }
}
