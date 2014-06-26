using System;
using System.Numerics;

namespace Secrets
{
    class Secrets
    {
        static void Main(string[] args)
        {
            BigInteger number;
            bool isInt;
            do
            {
                isInt = BigInteger.TryParse(Console.ReadLine(), out number);
            } while (isInt == false);

            if (number < 0)
            {
                number *= -1;
            }
            BigInteger tempNumber = number;

            BigInteger specialSum = 0;
            int counter = 0;

            for (int i = number.ToString().Length - 1; i >= 0; i--)
            {
                counter++;
                BigInteger currentDigit = tempNumber % 10;
                if (counter % 2 == 0)
                {
                    specialSum += currentDigit * currentDigit * counter;
                }
                else
                {
                    specialSum += currentDigit * counter * counter;
                }
                tempNumber /= 10;
            }

            Console.WriteLine(specialSum);
            int lastSpecialSumDigit = Convert.ToInt32(specialSum.ToString()[specialSum.ToString().Length - 1].ToString());
            string[] secretAlphaSequence = new string[lastSpecialSumDigit];

            BigInteger r = specialSum % 26;
            char letter = '\u0040';

            if (lastSpecialSumDigit == 0)
            {
                Console.WriteLine(number + " has no secret alpha-sequence");
            }
            else
            {
                for (int i = 0; i < lastSpecialSumDigit; i++)
                {

                    if (r == 26)
                    {
                        r = 0;
                    }
                    Console.Write((char)(letter + r + 1));
                    r++;
                }
            }
        }
    }
}
