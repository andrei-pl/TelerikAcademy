namespace ATM.Data
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    using ATM.Models;

    public class ATMContext : DbContext
    {
        public ATMContext()
            : base("ATM")
        {

        }

        public DbSet<CardAccount> CardAccounts { get; set; }
        public DbSet<TransactionHistory> TransactionsHistory { get; set; }
    }
}
