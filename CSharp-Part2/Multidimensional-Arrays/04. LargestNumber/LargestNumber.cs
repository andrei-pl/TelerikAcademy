using System;

namespace _04.LargestNumber
{
    class LargestNumber
    {
        static void Main(string[] args)
        {
            //Write a program, that reads from the console an array of N integers and an integer K, 
            //sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

            Console.WriteLine("Enter array length:");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write((i + 1) + ". ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter number for K:");
            int k = int.Parse(Console.ReadLine());
            Array.Sort(arr);

            int largestNumberIndex = Array.BinarySearch(arr, k);
            if (largestNumberIndex < 0)
            {
                if (largestNumberIndex == -1)
                {
                    Console.WriteLine("There is no number that is less than or equal to k.");
                }
                else
                {
                    Console.WriteLine(arr[~largestNumberIndex - 1]);
                }
            }
            else
            {
                Console.WriteLine(arr[largestNumberIndex]);
            }
        }
    }
}
