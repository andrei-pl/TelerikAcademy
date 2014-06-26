using System;

namespace _05.WorkingDays
{
    //Write a method that calculates the number of workdays between today and given date, passed as parameter. 
    //Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

    class WorkingDays
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an end date in DD.MM.YYYY format");
            string[] endDate = Console.ReadLine().Split('.');

            int day = int.Parse(endDate[0]);
            int month = int.Parse(endDate[1]);
            int year = int.Parse(endDate[2]);
            DateTime GivenDate = new DateTime(year, month, day);

            DateTime Today = DateTime.Today;

            if (Today > GivenDate)
            {
                Today = GivenDate;
                GivenDate = DateTime.Today;
            }

            DateTime[] Holidays = {
                                       new DateTime(2014, 1, 1),
                                       new DateTime(2014, 3, 1),
                                       new DateTime(2014, 5, 24),
                                       new DateTime(2014, 11, 30),
                                       new DateTime(2014, 12, 25),
                                       new DateTime(2014, 12, 26)
        };
            int workingDays = WorkingDaysOfPeriod(GivenDate, Today, Holidays);

            Console.WriteLine("Working days between {0} and {1}: {2} ", Today.ToString("d.M.yyyy"), GivenDate.ToString("d.M.yyyy"), workingDays);
        }

        private static int WorkingDaysOfPeriod(DateTime GivenDate, DateTime Today, DateTime[] Holidays)
        {
            int workingDays = 0;
            int daysLength = (GivenDate - Today).Days;
            for (int i = 0; i < daysLength; i++)
            {
                bool isHoliday = false;
                for (int j = 0; j < Holidays.Length; j++)
                {
                    if (Today == Holidays[j])
                    {
                        isHoliday = true;
                    }
                }
                if (Today.DayOfWeek == DayOfWeek.Saturday || Today.DayOfWeek == DayOfWeek.Sunday || isHoliday == true)
                {
                    Today = Today.AddDays(1);
                }
                else
                {
                    workingDays++;
                    Today = Today.AddDays(1);
                }
                isHoliday = false;
            }
            return workingDays;
        }
    }
}
