using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    class Worker : Human
    {
        public decimal WeekSalary { get; private set; }

        public int WorkHoursPerDay { get; private set; }

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursperDay)
            : base(firstName, lastName)
        {
            WeekSalary = weekSalary;
            WorkHoursPerDay = workHoursperDay;
        }

        public decimal MoneyPerHour()
        {
            return WeekSalary / (5 * WorkHoursPerDay);
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + MoneyPerHour();
        }
    }
}
