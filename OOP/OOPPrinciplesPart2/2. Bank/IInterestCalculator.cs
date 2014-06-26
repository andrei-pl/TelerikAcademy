using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    public interface IInterestCalculator
    {
        int PeriodInMonths { get; }

        decimal CalculateInterest();
    }
}
