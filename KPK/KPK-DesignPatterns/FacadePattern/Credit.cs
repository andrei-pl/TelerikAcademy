namespace FacadePattern
{
    using System;

    class Credit
    {
        public bool HasGoodCredit(Customer customer)
        {
            Console.WriteLine("Check credit for " + customer.Name);

            return true;
        }
    }
}
