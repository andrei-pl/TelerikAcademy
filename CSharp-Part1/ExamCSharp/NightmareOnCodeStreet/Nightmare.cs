using System;
using System.Numerics;

namespace NightmareOnCodeStreet
{
    class Nightmare
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            
            string number = "";
            string finalNumber = "";
            do
            {
                number = Console.ReadLine();
                for (int i = 0; i < number.Length; i++)
                {
                    if (i % 2 != 0 && char.IsDigit(number[i]))
                    {
                        finalNumber += number[i].ToString();
                    }
                }
            } while (number == "");

            BigInteger count = 0;
            BigInteger result = 0;

            for (int i = 0; i < finalNumber.Length; i++)
            {
                    BigInteger digit = BigInteger.Parse(finalNumber[i].ToString());
                    result += digit;
                    count++;
            }
            Console.WriteLine(count + " " + result);
            
        }
    }
}
