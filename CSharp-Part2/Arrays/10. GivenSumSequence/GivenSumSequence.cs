using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.GivenSumSequence
{
    //Write a program that finds in given array of integers a sequence of given sum S (if present). 
    //Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}	

    class GivenSumSequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write array length");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write((i + 1) + ". ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Write the required sum");
            int searchSum = int.Parse(Console.ReadLine());

            List<List<int>> sequenceList = new List<List<int>>();

            for (int i = 0; i < arr.Length; i++)
            {
                List<int> tempSequence = new List<int>();
                int sumTempSequence = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    sumTempSequence += arr[j];
                    tempSequence.Add(arr[j]);

                    if (sumTempSequence > searchSum)
                    {
                        break;
                    }
                    if (sumTempSequence == searchSum)
                    {
                        sequenceList.Add(new List<int>(tempSequence));
                        break;
                    }
                }
            }
            Console.WriteLine("The sequence with given sum is:");
            foreach (List<int> subList in sequenceList)
            {
                Console.WriteLine(string.Join(", ", subList));
            }
        }
    }
}
