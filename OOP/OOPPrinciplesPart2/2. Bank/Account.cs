using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    public abstract class Account : IDeposit
    {
        private Customer owner;
        public decimal Balance { get; set; }
        public decimal MonthlyInterestRate { get; set; }
        public IInterestCalculator interestCalculator;

        protected Account(Customer owner, decimal balance, decimal monthlyInterestRate)
        {
            this.owner = owner;
            this.Balance = balance;
            this.MonthlyInterestRate = monthlyInterestRate;
        }

        public decimal CalculateInterest(int months)
        {
            if (months <= 0)
            {
                throw new ArgumentException("The interest period should be a positive integer.");
            }

            return (this.interestCalculator.CalculateInterest() / this.interestCalculator.PeriodInMonths) * months;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }
}
