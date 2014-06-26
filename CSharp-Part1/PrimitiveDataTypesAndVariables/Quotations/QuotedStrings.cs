using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotedStrings
{
    //Declare two string variables and assign them with following value: "The "use" of quotations causes difficulties."
    //Do the above in two different ways: with and without using quoted strings.

    class QuotedStrings
    {
        static void Main(string[] args)
        {
            string quotation1 = "The \"use\" of quotations causes difficulties.";
            string quotation2 = "The use of quotations causes difficulties.";

            Console.WriteLine("{0}\n{1}", quotation1, quotation2);
        }
    }
}
