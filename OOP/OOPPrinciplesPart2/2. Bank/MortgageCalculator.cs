using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class MortgageCalculator : IInterestCalculator
    {
       private decimal principal;
        private int reducedInterestPeriodInMonths;
        private decimal reducedInterestRate;
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

        public int ReducedInterestPeriodInMonths
        {
            get
            {
                return reducedInterestPeriodInMonths;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Reduced interest period in months must be positive.");
                }
                reducedInterestPeriodInMonths = value;
            }
        }

        public decimal ReducedInterestRate
        {
            get
            {
                return reducedInterestRate;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Reduced interest rate cannot be negative.");
                }
                reducedInterestRate = value;
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

        public MortgageCalculator(
            Customer owner, decimal principal, decimal monthlyInterestRate, int periodInMonths)
        {
            this.Principal = principal;

            if (owner is IndividualCustomer)
            {
                this.ReducedInterestPeriodInMonths = 6;
                this.ReducedInterestRate = 0;
            }
            else
            {
                this.ReducedInterestPeriodInMonths = 12;
                this.ReducedInterestRate = monthlyInterestRate / 2;
            }

            this.MonthlyInterestRate = monthlyInterestRate;
            this.PeriodInMonths = periodInMonths;
        }

        public decimal CalculateInterest()
        {
            if (this.periodInMonths <= this.reducedInterestPeriodInMonths)
            {
                throw new ArgumentException("The period in months should be greater than the reduced interest period.");
            }

            return (this.reducedInterestRate / 100) * this.principal * this.reducedInterestPeriodInMonths +
                (this.monthlyInterestRate / 100) * this.principal * (this.periodInMonths - this.reducedInterestPeriodInMonths);
        }
    }
}
