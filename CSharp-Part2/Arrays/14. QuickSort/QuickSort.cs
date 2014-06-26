using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.QuickSort
{
    //Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

    class QuickSort
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of the array:");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            QuickSort_Array(numbers, 0, n - 1);

            Console.WriteLine(string.Join(", ", numbers));
        }

        static void QuickSort_Array(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    QuickSort_Array(arr, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    QuickSort_Array(arr, pivot + 1, right);
                }
            }
        }

        static int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                {
                    left++;
                }

                while (numbers[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}