using System;
using System.Numerics;

namespace NthTribonacci
{
    class NthTribonacci
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            BigInteger[] array = new BigInteger[n];
            array[0] = first;
            array[1] = second;
            array[2] = third;

            for (int i = 3; i < array.Length; i++)
            {
                array[i] = array[i - 1] + array[i - 2] + array[i - 3];
            }
            Console.WriteLine(array[n-1]);
        }
    }
}
