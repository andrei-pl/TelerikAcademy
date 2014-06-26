using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class DepositCalculator : IInterestCalculator
    {
        private decimal principal;
        private decimal minInterestPrincipal;
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

        public decimal MinInterestPrincipal
        {
            get
            {
                return minInterestPrincipal;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Minimum interest principal must be positive.");
                }
                minInterestPrincipal = value;
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

        public DepositCalculator(
            decimal principal, decimal monthlyInterestRate, int periodInMonths)
        {
            this.Principal = principal;
            this.MinInterestPrincipal = 1000;
            this.MonthlyInterestRate = monthlyInterestRate;
            this.PeriodInMonths = periodInMonths;
        }

        public decimal CalculateInterest()
        {
            if (this.principal < this.MinInterestPrincipal)
            {
                return 0;
            }

            return (this.monthlyInterestRate / 100) * this.principal * this.periodInMonths;
        }
    }
}
