using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MaxSumSequence
{
    //Write a program that finds the sequence of maximal sum in given array. Example:
	//{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
	//Can you do it with only one loop (with single scan through the elements of the array)?

    class MaxSumSequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write array length");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int arrSum = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write((i + 1) + ". ");
                arr[i] = int.Parse(Console.ReadLine());
                arrSum += arr[i];
            }

            List<int> sequenceList = new List<int>(arr);
            int sequenceSum = arrSum;

            for (int i = 0; i < arr.Length; i++)
            {
                List<int> tempSequence = new List<int>();
                int sumTempSequence = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    sumTempSequence += arr[j];
                    tempSequence.Add(arr[j]);

                    if (sumTempSequence >= sequenceSum && tempSequence.Count < sequenceList.Count)
                    {
                        sequenceList = new List<int>(tempSequence);
                        sequenceSum = sumTempSequence;
                    }
                }
            }
            Console.WriteLine("The maximal sum in given array is:");
            Console.WriteLine(string.Join(", ", sequenceList));
        }
    }
}
