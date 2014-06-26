using System;

namespace _02.BiggestInteger
{
    //Write a method GetMax() with two parameters that returns the bigger of two integers. 
    //Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

    class BiggestInteger
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 3 integers:");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int biggestInt = GetMax(a, b);
            biggestInt = GetMax(biggestInt, c);

            Console.WriteLine("The biggest number is: " + biggestInt);
        }

        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }
    }
}
