using System;

namespace _04.NumberAppear
{
    //Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.

    class NumberAppear
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length for the array");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Write {0} numbers", n);
            int[] arrray = new int[n];

            for (int i = 0; i < arrray.Length; i++)
            {
                Console.Write((i + 1) + ". ");
                arrray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter which number you want to check");
            int checkNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("The number {0} appears {1} times in the array.", checkNumber, CountNumber(arrray,checkNumber));
        }

        static int CountNumber(int[] arr, int number)
        {
            int counter = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (number == arr[i])
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
