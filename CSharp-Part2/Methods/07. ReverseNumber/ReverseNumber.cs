using System;

namespace _07.ReverseNumber
{
    //Write a method that reverses the digits of given decimal number. Example: 256 -> 652
    
    class ReverseNumber
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            Console.WriteLine("Enter number for reversing");
            decimal n = decimal.Parse(Console.ReadLine());

            Console.WriteLine("The reversed number is " + Reverse(n));
        }

        static decimal Reverse(decimal number)
        {
            string strNumber = number.ToString();
            string newNumber = "";

            for (int i = strNumber.Length - 1; i >= 0; i--)
            {
                newNumber += strNumber[i].ToString();
            }
            return decimal.Parse(newNumber);
        }
    }
}
