using System;

namespace _09.MaxElementInPortion
{
    //Write a method that return the maximal element in a portion of array of integers starting at given index. 
    //Using it write another method that sorts an array in ascending / descending order.

    class MaxElementInPortion
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length for the array");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Write {0} numbers", n);
            int[] array = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(i + ". ");
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Write the index from which to start searching (starting from 0)");
            int index = int.Parse(Console.ReadLine());
            index = MaximalInteger(array, index, array.Length);

            Console.WriteLine("The maximal number is " + array[index]);

            Console.WriteLine("Enter which way the array to be sorted (ascending or descending):");
            string sort = Console.ReadLine();
            int[] sortedArray = AscDescOrderSort(array, sort);

            for (int i = 0; i < sortedArray.Length; i++)
            {
                Console.Write(sortedArray[i] + " ");
            }
        }

        //Ascending or Descending sort
        static int[] AscDescOrderSort(int[] array, string order)
        {
            int[] arr = new int[array.Length];
            Array.Copy(array, arr, array.Length);
            if (order == "ascending")
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    int maxIndex = MaximalInteger(arr, 0, i);
                    if (arr[maxIndex] > arr[i])
                    {
                        int temp = arr[maxIndex];
                        arr[maxIndex] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    int maxIndex = MaximalInteger(arr, i + 1, arr.Length);
                    if (arr[maxIndex] > arr[i])
                    {
                        int temp = arr[maxIndex];
                        arr[maxIndex] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            return arr;
        }

        //return the index of the maximal number
        static int MaximalInteger(int[] array, int start, int end)
        {
            int index = 0;
            int max = int.MinValue;
            for (int i = start; i < end; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                    index = i;
                }
            }
            return index;
        }
    }
}
