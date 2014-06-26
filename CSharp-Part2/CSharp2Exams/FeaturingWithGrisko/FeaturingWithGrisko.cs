using System;
using System.Collections.Generic;

namespace _19.PermutationsOfN
{

    class PermutationsOfN
    {
        static void Main()
        {
            string n = Console.ReadLine();
            char[] arr = n.ToCharArray();
            int count = 0;
            Array.Sort(arr);

            do
            {
                if (IsMatch(arr))
                {
                    count++;
                }
            }
            while (NextPermutation(arr));
            Console.WriteLine(count);
        }
        //static HashSet<string> word = new HashSet<string>();

        private static bool NextPermutation(char[] array)
        {
            for (int index = array.Length - 2; index >= 0; index--)
            {
                if (array[index] < array[index + 1])
                {
                    int swapWithIndex = array.Length - 1;
                    while (array[index] >= array[swapWithIndex])
                    {
                        swapWithIndex--;
                    }

                    // Swap i-th and j-th elements
                    var tmp = array[index];
                    array[index] = array[swapWithIndex];
                    array[swapWithIndex] = tmp;

                    Array.Reverse(array, index + 1, array.Length - index - 1);
                    return true;
                }
            }
            return false;
        }

        static bool IsMatch(char[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
//        static void GeneratePermutations(char[] arr, int k)
//        {
//            if (k > arr.Length - 1)
//            {
//                for (int i = 0; i < arr.Length; i++)
//                {
//                    if (i == arr.Length - 1)
//                    {
//                        word.Add(new string(arr));
//                    }
//                    else
//                    {
//                        if (arr[i] == arr[i + 1])
//                        {
//                            break;
//                        }
//                    }
//                }
//            }
//            else
//            {
//                GeneratePermutations(arr, k + 1);
//                for (int i = k + 1; i < arr.Length; i++)
//                {
//                    Swap(ref arr[k], ref arr[i]);
//                    GeneratePermutations(arr, k + 1);
//                    Swap(ref arr[k], ref arr[i]);
//                }
//            }
//        }

//        static void Swap(ref char first, ref char second)
//        {
//            char oldFirst = first;
//            first = second;
//            second = oldFirst;
//        }
    }
}