using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Events
{
    //08. * Read in MSDN about the keyword event in C# and how to publish events. Re-implement the above using .NET events and following the best practices.

    class Program
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Handler handler = new Handler(pub);
            pub.Starter(2, 20);
        }
    }
}
