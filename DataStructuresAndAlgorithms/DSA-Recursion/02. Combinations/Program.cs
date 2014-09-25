namespace _02.Combinations
{
    using System;

    /// <summary>
    /// Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set. 
    /// Example: n=3, k=2  (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
    /// </summary>
    class Program
    {
        private static int[] arr;
        static void Main(string[] args)
        {
            Console.Write("Enter number of k elements: ");
            int k = int.Parse(Console.ReadLine());

            Console.Write("Enter number n for the array size: ");
            int n = int.Parse(Console.ReadLine());

            arr = new int[n];
            Print(0, k, 1);
        }

        private static void Print(int index, int k, int nextCicle)
        {
            for (int i = nextCicle; i <= k; i++)
            {
                if(index == arr.Length)
                {
                    Console.WriteLine(string.Join(" ", arr));
                    return;
                }

                arr[index++] = i;
                Print(index, k, i);
                index--;
            }
        }
    }
}
