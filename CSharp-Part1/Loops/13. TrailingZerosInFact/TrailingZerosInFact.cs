using System;
using System.Numerics;

namespace _13.TrailingZerosInFact
{
    //* Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
	//N = 10 -> N! = 3628800 -> 2
	//N = 20 -> N! = 2432902008176640000 -> 4
	//Does your program work for N = 50 000? - Of couurse it does!!!
	//Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!

    class TrailingZerosInFact
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integer for N! : ");
            int n = int.Parse(Console.ReadLine());

            if (n >= 0)
            {
                BigInteger factN = 1;

                for (int i = 1; i <= n; i++)
                {
                    factN *= i;
                }
                string factString = factN.ToString();
                int counter = 0;

                for (int i = factString.Length - 1; i >= 0 ; i--)
                {
                    if (factString[i] != '0')
                    {
                        break;
                    }
                    if (factString[i] == '0')
                    {
                        counter++;
                    }
                }

                Console.WriteLine("N! = " + factN);
                Console.WriteLine(counter + " trailing zeros.");
            }
            else
            {
                Console.WriteLine("Invalid numbers!");
            }
        }
    }
}
