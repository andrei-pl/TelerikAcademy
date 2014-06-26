using System;

namespace _02.Compare2Arrays
{
    //Write a program that reads two arrays from the console and compares them element by element.

    class Compare2Arrays
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length for first array");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter length for second array");
            int m = int.Parse(Console.ReadLine());

            int[] arr1 = new int[n];
            int[] arr2 = new int[m];
            bool equal = true;

            for (int i = 0; i < n; i++)
            {
                Console.Write("arr1[" + i + "] = ");
                arr1[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < m; i++)
            {
                Console.Write("arr2[" + i + "] = ");
                arr2[i] = int.Parse(Console.ReadLine());
            }

            int length = (n <= m) ? n : m;
            for (int i = 0; i < length; i++)
            {
                if (arr1[i] < arr2[i])
                {
                    Console.WriteLine("arr1[{0}] is smaller than arr2[{0}]", i);
                    equal = false;
                }
                else if (arr1[i] > arr2[i])
                {
                    Console.WriteLine("arr2[{0}] is smaller than arr1[{0}]", i);
                    equal = false;
                }
                else
                {
                    Console.WriteLine("arr2[{0}] and arr1[{0}] are equal", i);
                }
            }
            if (m == n)
            {
                
            }
            else
            {
                equal = false;
            }
            Console.WriteLine("Arrays are {0}", (equal?"equal":"not equal"));
        }
    }
}