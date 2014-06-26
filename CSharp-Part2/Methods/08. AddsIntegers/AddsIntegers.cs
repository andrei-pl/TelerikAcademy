using System;
using System.Numerics;

namespace _08.AddsIntegers
{
    //Write a method that adds two positive integer numbers represented as arrays of digits 
    //(each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
    //Each of the numbers that will be added could have up to 10 000 digits.

    class AddsIntegers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number");
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            BigInteger[] array1 = new BigInteger[n.ToString().Length];

            array1 = NumberInArray(n);
            
            Console.WriteLine("Enter the second number");
            BigInteger m = BigInteger.Parse(Console.ReadLine());
            BigInteger[] array2 = new BigInteger[m.ToString().Length];

            array2 = NumberInArray(m);

            BigInteger newNumber = AddIntegers(array1, array2);
            Console.WriteLine("The new number is " + newNumber);
        }

        static BigInteger[] NumberInArray(BigInteger numnber)
        {
            int count = 0;
            BigInteger[] array = new BigInteger[numnber.ToString().Length];

            while (numnber > 0)
            {
                array[count] = numnber % 10;
                numnber = numnber / 10;
                count++;
            }
            return array;
        }

        static BigInteger AddIntegers(BigInteger[] arr1, BigInteger[] arr2)
        {
            int arrLength = 0;

            if(arr1.Length >= arr2.Length)
            {
                arrLength = arr1.Length + 1; //The length might get longer with one than the longer number
            }
            else
            {
                arrLength = arr2.Length + 1;
            }

            BigInteger[] newNumberArray = new BigInteger[arrLength];

            for (int i = 0; i < newNumberArray.Length; i++)
            {
                if (i < arr1.Length)
                {
                    newNumberArray[i] += arr1[i];
                }
                if (i < arr2.Length)
                {
                    newNumberArray[i] += arr2[i];
                }
                if (newNumberArray[i] >= 10)
                {
                    newNumberArray[i] -= 10;
                    newNumberArray[i + 1] = 1;
                }
            }
            string s = "";
            for (int i = newNumberArray.Length - 1; i >= 0; i--)
            {
                s += newNumberArray[i];
            }
            BigInteger newNumber = BigInteger.Parse(s);

            return newNumber;
        }
    }
}
