using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.MergeSort
{
    // * Write a program that sorts an array of integers using
    // the merge sort algorithm (find it in Wikipedia).

    class MergeSort
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the size of array: ");
            int arraySize = Int32.Parse(Console.ReadLine());

            int[] array = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write("Enter element {0}: ", i + 1);
                array[i] = Int32.Parse(Console.ReadLine());
            }

            array = Splits(array);
            Console.WriteLine(string.Join(", ", array));
        }

        static int[] Splits(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr;
            }
            int middle = arr.Length / 2;
            int[] leftArray = new int[middle];
            int[] rightArray = new int[arr.Length - middle];

            for (int i = 0; i < leftArray.Length; i++)
            {
                leftArray[i] = arr[i];
            }
            for (int i = 0; i < rightArray.Length; i++)
            {
                rightArray[i] = arr[middle + i];
            }
            leftArray = Splits(leftArray);
            rightArray = Splits(rightArray);

            return Merge(leftArray, rightArray);
        }

        static int[] Merge(int[] left, int[] right)
        {
            int[] mergedArray = new int[left.Length + right.Length];
            int leftInc = 0;
            int rightInc = 0;

            for (int i = 0; i < mergedArray.Length; i++)
            {
                if (rightInc == right.Length || (leftInc < left.Length && left[leftInc] <= right[rightInc]))
                {
                    mergedArray[i] = left[leftInc];
                    leftInc++;
                }
                else if (leftInc == left.Length || (rightInc < right.Length && left[leftInc] >= right[rightInc]))
                {
                    mergedArray[i] = right[rightInc];
                    rightInc++;
                }
            }

            return mergedArray;
        }
    }
}
