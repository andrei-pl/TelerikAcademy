using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF.Service
{
    /// <summary>
    ///  1. Create a simple WCF service. It should have a method that accepts a DateTime parameter and returns the day of week (in Bulgarian) as string. 
    ///  Test it with the integrated WCF client.
    /// </summary>
    public class TimeService : ITimeService
    {

        public string GetDayFromData(DateTime date)
        {
            var bulgarian = new System.Globalization.CultureInfo("bg-BG");
            var day = bulgarian.DateTimeFormat.GetDayName(date.DayOfWeek);
            return day.ToString();
        }
    }
}
