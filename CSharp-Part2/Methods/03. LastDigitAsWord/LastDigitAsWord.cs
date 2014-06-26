using System;

namespace _03.LastDigitAsWord
{
    //Write a method that returns the last digit of given integer as an English word. Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".

    class LastDigitAsWord
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some integer:");
            int number = int.Parse(Console.ReadLine());

            Console.Write("The last digit of this number is ");
            DigitAsWord(number);
        }

        static void DigitAsWord(int a)
        {
            int digit = a % 10;

            if (digit < 0)
            {
                digit *= -1;
            }

            switch (digit)
            {
                case 0: Console.WriteLine("zero"); break;
                case 1: Console.WriteLine("one"); break;
                case 2: Console.WriteLine("two"); break;
                case 3: Console.WriteLine("three"); break;
                case 4: Console.WriteLine("four"); break;
                case 5: Console.WriteLine("five"); break;
                case 6: Console.WriteLine("six"); break;
                case 7: Console.WriteLine("seven"); break;
                case 8: Console.WriteLine("eight"); break;
                case 9: Console.WriteLine("nine"); break;
                default: Console.WriteLine("Invalid value."); break;
            }
        }
    }
}
