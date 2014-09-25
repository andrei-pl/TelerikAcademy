namespace Divisors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        private static List<int> permutations = new List<int>();
        private static StringBuilder arr = new StringBuilder();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                arr.Append(int.Parse(Console.ReadLine()));
            }

            GeneratePermutations(0);

            int minNumber = 0;
            int minDivisors = int.MaxValue;

            foreach (var number in permutations)
            {
                var tempDivisors = 0;

                for (int i = 1; i <= number/2; i++)
                {
                    if(number % i == 0)
                    {
                        tempDivisors++;
                    }
                }

                if(tempDivisors < minDivisors)
                {
                    minDivisors = tempDivisors;
                    minNumber = number;
                }
                else if(tempDivisors == minDivisors && number < minNumber)
                {
                    minDivisors = tempDivisors;
                    minNumber = number;
                }
            }

            Console.WriteLine(minNumber);
        }

        static void GeneratePermutations(int k)
        {
            if (k == arr.Length)
            {
                permutations.Add(int.Parse(arr.ToString()));
            }
            else
            {
                GeneratePermutations(k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    if (!arr[k].Equals(arr[i]))
                    {
                        Swap(k, i);
                        GeneratePermutations(k + 1);
                        Swap(k, i);
                    }
                }
            }
        }

        static void Swap(int first, int second)
        {
            char oldFirst = arr[first];
            arr[first] = arr[second];
            arr[second] = oldFirst;
        }
    }
}
