using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextDate
{
    class NextDate
    {
        static void Main(string[] args)
        {
            int date = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            if (date == 31 && month == 12)
            {
                year++;
            }
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (date == 31)
                {
                    date = 1;
                    if (month == 12)
                    {
                        month = 1;
                    }
                    else
                    {
                        month++;
                    }
                }
                else
                {
                    date++;
                }
            }
            else if (month == 2)
            {
                if (date == 28)
                {
                    if (year % 4 != 0)
                    {
                        date = 1;
                        month++;
                    }
                    else
                    {
                        date++;
                    }
                }
                else if (date == 29)
                {
                    date = 1;
                    month++;
                }
                else
                {
                    date++;
                }
            }
            else
            {
                if (date == 30)
                {
                    date = 1;
                    month++;
                }
                else
                {
                    date++;
                }
            }
            Console.WriteLine(date + "." + month + "." + year);
        }
    }
}
