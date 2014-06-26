using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class Deposit : Account, IWithDraw
    {
         public Deposit(
            Customer owner,
            decimal balance,
            decimal monthlyInterestRate,
            int periodInMonths)
            : base(owner, balance, monthlyInterestRate)
        {
            this.interestCalculator = new DepositCalculator(
                balance, monthlyInterestRate, periodInMonths);
        }

        public void WithDraw(decimal amount)
        {
            Balance -= amount;
        }
    }
}
