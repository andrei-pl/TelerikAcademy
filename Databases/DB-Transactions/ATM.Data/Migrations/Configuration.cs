namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ATM.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ATMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ATM.Data.ATMContext";
        }

        protected override void Seed(ATMContext context)
        {
          //   using (ATMContext db = new ATMContext())
          //  {
          // 
          //      for (int i = 0; i < 4; i++)
          //      {
          //          db.CardAccounts.Add(
          //              new CardAccount
          //              {
          //                  CardNumber = 1000 + i,
          //                  CardCash = 100 + 10 * i,
          //                  CardPIN = 100 + i,
          //              });
          //          db.SaveChanges();
          //      }
          //  }
        }
    }
}
