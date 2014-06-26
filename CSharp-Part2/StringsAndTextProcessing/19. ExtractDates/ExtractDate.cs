using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _19.ExtractDates
{
    //Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.

    class ExtractDates
    {
        static void Main()
        {
            string text = "Contact Telerik at 15.03.2012 or 16.02.2002";

            DateTime date;
            string format = "dd.MM.yyyy";

            foreach (Match item in Regex.Matches(text, @"\b\d{2}\.\d{2}\.\d{4}\b"))
            {
                if (DateTime.TryParseExact(item.Value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    Console.WriteLine(date.ToString(format, CultureInfo.GetCultureInfo("en-CA")));
                }
            }
        }
    }
}
