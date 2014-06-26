using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class LoanCalculator : IInterestCalculator
    {
        private decimal principal;
        private int interestFreePeriodInMonths;
        private decimal monthlyInterestRate;
        private int periodInMonths;

        public decimal Principal
        {
            get
            {
                return principal;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Principal must be positive.");
                }
                principal = value;
            }
        }

        public int InterestFreePeriodInMonths
        {
            get
            {
                return interestFreePeriodInMonths;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Interest-free period in months must be positive.");
                }
                interestFreePeriodInMonths = value;
            }
        }

        public decimal MonthlyInterestRate
        {
            get
            {
                return monthlyInterestRate;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Interest rate must be positive.");
                }
                monthlyInterestRate = value;
            }
        }

        public int PeriodInMonths
        {
            get
            {
                return periodInMonths;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Period in months must be positive.");
                }
                periodInMonths = value;
            }
        }

        public LoanCalculator(
            Customer owner, decimal principal, decimal monthlyInterestRate, int periodInMonths)
        {
            this.Principal = principal;

            if (owner is IndividualCustomer)
            {
                this.InterestFreePeriodInMonths = 3;
            }
            else
            {
                this.InterestFreePeriodInMonths = 2;
            }

            this.MonthlyInterestRate = monthlyInterestRate;
            this.PeriodInMonths = periodInMonths;
        }

        public decimal CalculateInterest()
        {
            if (this.periodInMonths <= this.interestFreePeriodInMonths)
            {
                throw new ArgumentException("The period in months should be greater than the interest-free period.");
            }

            return (this.monthlyInterestRate / 100) * this.principal * (this.periodInMonths - this.interestFreePeriodInMonths);
        }
    }
}
