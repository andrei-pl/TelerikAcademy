using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        //Write a program that compares two char arrays lexicographically (letter by letter).

        static void Main(string[] args)
        {
            Console.WriteLine("Enter length for the first array:");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter length for the second array:");
            int m = Int32.Parse(Console.ReadLine());

            char[] array1 = new char[n];
            char[] array2 = new char[m];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter value for {0}-th element of first array: ", i + 1);
                array1[i] = char.Parse(Console.ReadLine());
            }
            for (int i = 0; i < m; i++)
            {
                Console.Write("Enter value for {0}-th element of second array: ", i + 1);
                array2[i] = char.Parse(Console.ReadLine());
            }
            int length = n;

            if (n < m)
            {
                length = m;
            }
            
            bool isEqual = true;
            for (int i = 0; i < length; i++)
            {
                if (array1[i] < array2[i] || (i == n - 1 && n < m))
                {
                    Console.WriteLine("Lexicographically the first array is first");
                    isEqual = false;
                    break;
                }
                else if (array1[i] > array2[i] || (i == m - 1 && m < n))
                {
                    Console.WriteLine("Lexicographically the second array is first");
                    isEqual = false;
                    break;
                }
            }
            if (isEqual == true)
            {
                Console.WriteLine("The arrays are equal");
            }
        }
    }
}
