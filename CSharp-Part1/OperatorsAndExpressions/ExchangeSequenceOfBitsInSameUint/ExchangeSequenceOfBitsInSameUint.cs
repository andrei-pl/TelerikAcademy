using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeSequenceOfBitsInSameUint
{
    //* Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

    class ExchangeSequenceOfBitsInSameUint
    {
        static void Main(string[] args)
        {
            Console.Write("Enter uint number: ");
            uint number = UInt32.Parse(Console.ReadLine());

            int p;
            do
            {
                Console.Write("Enter the position of \"p\" for exchange (minor bits) from 1 to 31: ");
                p = Int32.Parse(Console.ReadLine());
            } while (p < 1 || p > 31);

            int q;
            do
            {
                Console.Write("Enter the position of \"q\" for exchange (elder bits) from " + (p + 1) + " to 32: ");
                q = Int32.Parse(Console.ReadLine());
            } while (q <= p || q > 32);

            int bitsForExchange;
            int range;
            do
            {
                range =  ((q - p) < (33 - q)) ? q - p : 33 - q; //It's 33 because the interface use range 1 - 32, only to be easyer counting rather than 0 - 31.
                Console.Write("Enter the number of bits you want to make exchange (x <= {0}): ", range);
                bitsForExchange = Int32.Parse(Console.ReadLine());
            } while (bitsForExchange < 0 || bitsForExchange > range);
                
            Console.WriteLine("The number befor exchange is: \n{0,15}=>{1} ", number,  Convert.ToString(number, 2).PadLeft(32, '0'));
            
            uint pMask = (uint)Math.Pow(2, bitsForExchange) - 1;
            uint qMask = pMask;

            pMask = pMask << (p - 1);
            qMask = qMask << (q - 1);
            uint pMaskValue = number & pMask;
            uint qMaskValue = number & qMask;
            
            number = (number & ~pMask) & ~qMask;

            pMaskValue = pMaskValue >> (p - 1);
            qMaskValue = qMaskValue >> (q - 1);

            number = (number | (pMaskValue << (q - 1))) | (qMaskValue << (p - 1));

            Console.WriteLine("The number after exchange is: \n{0,15}=>{1}", number, Convert.ToString(number, 2).PadLeft(32, '0'));
        }
    }
}
