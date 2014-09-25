namespace _01.NNestedLoops
{
    using System;

    /// <summary>
    /// Write a recursive program that simulates the execution of n nested loops from 1 to n. Examples:
    ///                           1 1 1
    ///                           1 1 2
    ///                           1 1 3
    ///         1 1               1 2 1
    ///n=2  ->  1 2      n=3  ->  ...
    ///         2 1               3 2 3
    ///         2 2               3 3 1
    ///                           3 3 2
    ///                           3 3 3
    ///
    /// </summary>
    class Program
    {
        private static int[] arr;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter number: ");
            int n = int.Parse(Console.ReadLine());
            arr = new int[n];

            Print(n, 0);
        }

        private static void Print(int n, int current)
        {
            for (int i = 1; i <= n; i++)
            {
                if (current == n)
                {
                    Console.WriteLine(string.Join(" ", arr));
                    return;
                }

                arr[current++] = i;
                Print(n, current);
                current--;
            }
        }
    }
}
