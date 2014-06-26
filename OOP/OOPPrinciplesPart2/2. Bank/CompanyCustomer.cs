using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class CompanyCustomer : Customer
    {
         public CompanyCustomer(string id, string name, string address, string phone)
            : base(id, name, String.Empty, address, phone)
        {
        }
    }
}
