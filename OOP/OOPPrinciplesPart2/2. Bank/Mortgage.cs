using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class Mortgage : Account
    {
        public Mortgage(
            Customer owner,
            decimal balance,
            decimal monthlyInterestRate,
            int periodInMonths)
            : base(owner, balance, monthlyInterestRate)
        {
            this.interestCalculator = new MortgageCalculator(
                owner, balance, monthlyInterestRate, periodInMonths);
        }
    }
}
