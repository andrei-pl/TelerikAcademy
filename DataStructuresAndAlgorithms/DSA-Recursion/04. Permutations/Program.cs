namespace _04.Permutations
{
    using System;

    /// <summary>
    /// Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n. 
    /// Example:	n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3},
    ///                   {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }

            GeneratePermutations(arr, 0);
        }

        static void GeneratePermutations<T>(T[] arr, int k)
        {
            if (k == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
