using System;

namespace _14._15.MinMaxAvrSumProdOFVariableArguments
{
    //Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.
    
    //* Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.). 
    //Use generic method (read in Internet about generic methods in C#).

    class MinMaxAvrSumProd
    {
        static void Main(string[] args)
        {
            Console.Write("The sum is: ");
            Console.WriteLine(CalcSum(1, 2, 3, 4));
            Console.Write("Min elements is: ");
            Console.WriteLine(MinElement(4, 7, 9, 11, 13));
            Console.Write("Max element is: ");
            Console.WriteLine(MaxElement(-2, 5, 68.5, 12, 4, 14));
            Console.Write("The average sum is: ");
            Console.WriteLine(AverageOfSequence(-2, 5, 12, 4, 14));
            Console.Write("The product is: ");
            Console.WriteLine(ProductOfElements(1, 3, 5, 7));
        }

        static T MinElement<T>(params T[] elements)
        {
            dynamic min = elements[0];

            foreach (var num in elements)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        }

        static T MaxElement<T>(params T[] elements)
        {
            dynamic max = elements[0];

            foreach (var num in elements)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }

        static T AverageOfSequence<T>(params T[] sequence)
        {
            dynamic sum = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                sum += sequence[i];
            }
            return sum /= sequence.Length;
        }

        static T CalcSum<T>(params T[] elements)
        {
            dynamic sum = 0;
            foreach (var num in elements)
            {
                sum += num;
            }
            return sum;
        }

        static T ProductOfElements<T>(params T[] elements)
        {
            dynamic product = 1;
            foreach (var num in elements)
            {
                product *= num;
            }
            return product;
        }

    }
}
