using System;

namespace _11._12.Polynomials
{
    //Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
	//x2 + 5 = 1x2 + 0x + 5 -> 5 0 1
    //Extend the program to support also subtraction and multiplication of polynomials.

    class Polynomials
    {
        static void Main(string[] args)
        {
            Console.Write("Enter length of first polynomial: ");
            int firstPolynomialLength = int.Parse(Console.ReadLine());

            int[] firstPol = new int[firstPolynomialLength];

            for (int i = 0; i < firstPol.Length; i++)
            {
                Console.Write((i + 1) + ". ");
                firstPol[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter length of second polynomial: ");
            int secondPolynomialLength = int.Parse(Console.ReadLine());

            int[] secondPol = new int[secondPolynomialLength];

            for (int i = 0; i < secondPol.Length; i++)
            {
                Console.Write((i + 1) + ". ");
                secondPol[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Addition");
            int[] result = PolynomsOperation(firstPol, secondPol, "addition");
            PrintResult(result);
            Console.WriteLine("Subtraction");
            result = PolynomsOperation(firstPol, secondPol, "subtraction");
            PrintResult(result);
            Console.WriteLine("Multiplication");
            result = PolynomsOperation(firstPol, secondPol, "multiplication");
            PrintResult(result);
        }

        private static void PrintResult(int[] result)
        {
            Console.Write(result[result.Length - 1] + "x^" + (result.Length - 1));
            for (int i = result.Length - 2; i > 0; i--)
            {
                if (result[i] >= 0)
                {
                    Console.Write(" + " + result[i] + "x^" + i);
                }
                else
                {
                    Console.Write(" " + result[i] + "x^" + i);
                }
            }
            if (result[0] >= 0)
            {
                Console.WriteLine(" + " + result[0]);
            }
            else
            {
                Console.WriteLine(" " +result[0]);
            }
        }

        //The logic for all operations differs only in one line
        private static int[] PolynomsOperation(int[] firstPol, int[] secondPol, string operation)
        {
            int newPolLength = 0;

            if (firstPol.Length >= secondPol.Length)
            {
                newPolLength = firstPol.Length;
            }
            else
            {
                newPolLength = secondPol.Length;
            }
            int[] newPol = new int[newPolLength];

            for (int i = 0; i < newPol.Length; i++)
            {
                if (i >= firstPol.Length || i >= secondPol.Length)
                {
                    if (i >= firstPol.Length)
                    {
                        newPol[i] = secondPol[i];
                    }
                    else
                    {
                        newPol[i] = firstPol[i];
                    }
                }
                else
                {   //only here is the difference
                    if (operation == "addition")
                    {
                        newPol[i] = PolynomAddition(firstPol[i], secondPol[i]);
                    }
                    else if (operation == "subtraction")
                    {
                        newPol[i] = PolynomSubtraction(firstPol[i], secondPol[i]);
                    }
                    else if (operation == "multiplication") 
                    {
                        newPol[i] = PolynomMultiplication(firstPol[i], secondPol[i]);
                    }
                }
            }
            return newPol;
        }

        private static int PolynomAddition(int firstPol, int secondPol)
        {
            return firstPol + secondPol;
        }

        private static int PolynomSubtraction(int firstPol, int secondPol)
        {
            return firstPol - secondPol;
        }

        private static int PolynomMultiplication(int firstPol, int secondPol)
        {
            return firstPol * secondPol;
        }
    }
}
