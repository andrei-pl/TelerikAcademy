using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer depositAccountCustomer = new IndividualCustomer(
    "2343PJ34752",
    "William",
    "Harris",
    "1 Microsoft Way, Redmond, WA",
    "1-888-553-6562");

            Deposit depositAccount = new Deposit(
                depositAccountCustomer,
                2500,
                1.0825M,
                12);

            Customer loanAccountCustomer = new CompanyCustomer(
                "89BPQ123YJ0",
                "Oracle Corporation",
                "500 Oracle Parkway, Redwood Shores, Redwood City, California, United States",
                "1-981-717-9366");

            Account loanAccount = new Loan(
                loanAccountCustomer,
                1000000000,
                1.0931M,
                24);

            Customer mortgageLoanAccountCustomer = new IndividualCustomer(
                "97A20LX3YJU",
                "Ginni",
                "Rometty",
                "Armonk, New York, U.S.",
                "1-129-342-3817");

            Account mortgageLoanAccount = new Mortgage(
                mortgageLoanAccountCustomer,
                300000,
                1.0875M,
                36);

            decimal depositInterest = depositAccount.CalculateInterest(3);
            Console.WriteLine("Deposit account interest: {0:C2}", depositInterest);

            depositAccount.Deposit(459.76M);
            depositAccount.WithDraw(400.76M);

            Console.WriteLine("Deposit account balance: {0:C2}", depositAccount.Balance);

            decimal loanInterest = loanAccount.CalculateInterest(10);
            Console.WriteLine("Loan account interest: {0:C2}", loanInterest);

            decimal mortgageLoanInterest = mortgageLoanAccount.CalculateInterest(10);
            Console.WriteLine("Mortgage loan account interest: {0:C2}", mortgageLoanInterest);
        }
    }
}
