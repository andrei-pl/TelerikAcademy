namespace ATM.Model
{
    using System;

    public class TransactionHistory
    {
        public int Id { get; set; }

        public int CardNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Ammount { get; set; }
    }
}
