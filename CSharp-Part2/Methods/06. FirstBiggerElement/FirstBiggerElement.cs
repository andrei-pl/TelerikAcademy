using System;

namespace _06.FirstBiggerElement
{
    //Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
    //Use the method from the previous exercise.

    class FirstBiggerElement
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length for the array");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Write {0} numbers", n);
            int[] array = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write((i + 1) + ". ");
                array[i] = int.Parse(Console.ReadLine());
            }
            
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (i == BiggerOrNot(array, i))
                {
                    Console.WriteLine("{0} is the first number bigger than its neighbors.", array[i]);
                    break;
                }
                if (i == array.Length - 2)
                {
                    Console.WriteLine("There are no elements that are bigger than their neighbors");
                }
            }
            
        }

        static int BiggerOrNot(int[] arr, int n)
        {
            if (arr[n] > arr[n - 1] && arr[n] > arr[n + 1])
            {
                return n;
            }
            return -1;
        }
    }
}
