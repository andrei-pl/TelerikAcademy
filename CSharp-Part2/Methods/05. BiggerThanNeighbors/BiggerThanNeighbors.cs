using System;

namespace _05.BiggerThanNeighbors
{
    //Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

    class BiggerThanNeighbors
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length for the array");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Write {0} numbers", n);
            int[] array = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write((i + 1) + ". ");
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the position you want to check, starts from 1:");
            int position = int.Parse(Console.ReadLine());

            if (BiggerOrNot(array, position - 1))
            {
                Console.WriteLine("The number {0} at position {1} is bigger than its neighbors.", array[position - 1], position);
            }
            else
            {
                Console.WriteLine("The number at position {0} is not bigger than its neighbors.", position);
            }
            //Checks for every position
            //for (int i = 1; i < array.Length - 1; i++)
            //{
            //    if (BiggerOrNot(array, i))
            //    {
            //        Console.WriteLine("array[{0}] = {1} is bigger than its neighbors.", i, array[i]);
            //    }
            //}
        }

        static bool BiggerOrNot(int[] arr, int n)
        {
            if (n <= 0 || n >= arr.Length - 1)
            {
                return false;
            }
            if (arr[n] > arr[n - 1] && arr[n] > arr[n + 1])
            {
                return true;
            }
            return false;
        }
    }
}
