namespace _09.FiftyMembersSequence
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// We are given the following sequence:
    ///S1 = N;
    ///S2 = S1 + 1;
    ///S3 = 2*S1 + 1;
    ///S4 = S1 + 2;
    ///S5 = S2 + 1;
    ///S6 = 2*S2 + 1;
    ///S7 = S2 + 2;
    ///...
    ///Using the Queue<T> class write a program to print its first 50 members for given N.
    ///Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            const int capacity = 50;

            Queue<int> sequence = new Queue<int>(capacity);
            List<int> result = new List<int>();

            Console.WriteLine("Enter first number.");
            string stringNumber = Console.ReadLine();
            int number = int.Parse(stringNumber);
            sequence.Enqueue(number);
            result.Add(number);

            int currentConstValue = sequence.Dequeue();
            for (int i = 0; i < capacity - 1; i++)
            {
                if (i % 3 == 0)
                {
                    sequence.Enqueue(currentConstValue + 1);
                    result.Add(currentConstValue + 1);
                }
                else if (i % 3 == 1)
                {
                    sequence.Enqueue(2 * currentConstValue + 1);
                    result.Add(2 * currentConstValue + 1);
                }
                else
                {
                    sequence.Enqueue(currentConstValue + 2);
                    result.Add(currentConstValue + 2);
                    currentConstValue = sequence.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
