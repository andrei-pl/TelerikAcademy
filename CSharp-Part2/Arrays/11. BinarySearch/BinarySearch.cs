using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.BinarySearch
{
    //Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).

    class BinarySearch
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write array length");
            int n = int.Parse(Console.ReadLine());
            List<int> arr = new List<int>();

            for (int i = 0; i < n; i++)
            {
                Console.Write((i + 1) + ". ");
                arr.Add(int.Parse(Console.ReadLine()));
            }
            arr.Sort();

            Console.WriteLine("Enter searching number:");
            int num = int.Parse(Console.ReadLine());
            //int index = arr.Count / 2;
            bool isFound = false;

            int left = 0;
            int right = arr.Count - 1;
            int index = (left + right) / 2;

            while (left <= right && isFound == false)
            {
                index = (left + right) / 2;

                if (arr[index] == num)
                {
                    isFound = true;
                }
                else if (arr[index] > num)
                {
                    right = index - 1;
                }
                else
                {
                    left = index + 1;
                }
            }

                                        //before to see the solution
            //while (isFound == false)
            //{
            //    if (arr[index] == num)
            //    {
            //        isFound = true;
            //    }
            //    else
            //    {
            //        if (index == 0 || index == arr.Count - 1)
            //        {
            //            break;
            //        }
            //        if (arr[index] > num)
            //        {
            //            index /= 2;
            //        }
            //        else
            //        {
            //            index = (arr.Count - index) / 2 + index;
            //        }
            //    }
            //}
            if (isFound)
            {
                Console.WriteLine("Founded: index = " + index);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
    }
}
