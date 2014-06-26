using System;

namespace _07.AnyToAnySystem
{
    //Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

    class AnyToAnyBase
    {
        static int AnyToDecimalRecursion(string num, int pow, int number = 0)
        {
            if (num == "")
            {
                return number;
            }
            if (num[0] >= 'A')
            {
                number += (num[0] - 'A' + 10) * (int)Math.Pow(pow, num.Length - 1);
            }
            else
            {
                number += (num[0] - '0') * (int)Math.Pow(pow, num.Length - 1);
            }
            return AnyToDecimalRecursion(num.Remove(0, 1), pow, number);
        }

        static string DecimalToAnyRecursion(int num, int pow, string hex = "")
        {
            if (num == 0)
            {
                return hex;
            }
            if ((num % pow) > 9)
            {
                hex = (char)((num % pow) + 'A' - 10) + hex;
            }
            else
            {
                hex = (char)((num % pow) + '0') + hex;
            }

            return DecimalToAnyRecursion(num / pow, pow, hex);
        }

        static void Main()
        {
            Console.WriteLine("Enter from what base you want to convert");
            int baseToConvert = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number:");
            string number = Console.ReadLine();
            Console.WriteLine("Enter to which base you want to convert");
            int convertedBase = int.Parse(Console.ReadLine());

            int num = 0;
            if (baseToConvert == 10)
            {
                num = int.Parse(number);
                Console.Write("The number in base {0} is: ", convertedBase);
                Console.WriteLine(DecimalToAnyRecursion(num, convertedBase));
            }
            else
            {
                num = AnyToDecimalRecursion(number, baseToConvert);
                Console.Write("The number in base {0} is: ", convertedBase);
                if (convertedBase == 10)
                {
                    Console.WriteLine(num);
                }
                else
                {
                    Console.WriteLine(DecimalToAnyRecursion(num, convertedBase));
                }
            }
        }
    }
}
