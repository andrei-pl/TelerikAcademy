namespace ATM
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Transactions;

    using ATM.Data;
    using ATM.Data.Migrations;
    using ATM.Models;

    class Program
    {
        static void Main(string[] args)
        {
            // Database creates in (localdb)\v11.0

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMContext, Configuration>());

            ATMActions.ShowCards();

           // Uncomment the text in Seed method in ATM.Data.Migrations.Configuration to create new accounts with cards
           
            int pin = 103;
            int cardNumber = 1003;
            decimal moneyToWithdraw = 100m;
            
            using (ATMContext db = new ATMContext())
            {
                if (ATMActions.WithdrawMoney(pin, cardNumber, moneyToWithdraw, db))
                {
                    Console.WriteLine("Money withdrawn");
                }
                else
                {
                    Console.WriteLine("Unfinalized transaction");
                }
            }
            
            
            Console.WriteLine("\nNew cards: ");
            ATMActions.ShowCards();
        }
    }
}
