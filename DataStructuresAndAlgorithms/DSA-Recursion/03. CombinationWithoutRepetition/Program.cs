namespace _03.CombinationWithoutRepetition
{
    using System;

    /// <summary>
    /// Modify the previous program to skip duplicates:
    /// n=4, k=2  (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
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
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }
            for (int i = nextCicle; i <= k; i++)
            {
                arr[index++] = i;
                Print(index, k, i + 1);
                index--;
            }
        }
    }
}
