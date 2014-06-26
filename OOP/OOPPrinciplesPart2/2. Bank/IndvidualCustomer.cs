using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class IndividualCustomer : Customer
    {
        public IndividualCustomer(string id, string name, string lastName, string address, string phone)
            : base(id, name, lastName, address, phone)
        {
        }
    }
}
