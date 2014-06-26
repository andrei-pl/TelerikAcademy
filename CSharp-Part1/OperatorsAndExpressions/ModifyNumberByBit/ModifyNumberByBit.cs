using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyNumberByBit
{
    class ModifyNumberByBit
    {
        //We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators 
        //that modifies n to hold the value v at the position p from the binary representation of n. Example: 
        //n = 5 (00000101), p=3, v=1 -> 13 (00001101); n = 5 (00000101), p=2, v=0 -> 1 (00000001)

        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int n = Int32.Parse(Console.ReadLine());

            Console.Write("Enter \"0\" or \"1\" for the bit value: ");
            int v = Int32.Parse(Console.ReadLine());

            Console.Write("Enter which bit you want to change (counting from 0): ");
            int p = Int32.Parse(Console.ReadLine());

            Console.WriteLine("{0,10}=>{1}", n, Convert.ToString(n, 2).PadLeft(32, '0'));
       
            int mask;
            int newNumber;

            if (v == 1)
            {
                mask = 1 << p;
                newNumber = n | mask;
            }
            else
            {
                mask = ~(1 << p);
                newNumber = n & mask;
            }

            n = newNumber;

            Console.WriteLine("The new number is: \n{0,10}=>{1}", n, Convert.ToString(n, 2).PadLeft(32, '0'));
        }
    }
}
