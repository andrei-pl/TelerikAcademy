using System;
using System.Text;

namespace _03.CheckBrackets
{
    //Write a program to check if in a given expression the brackets are put correctly.
    //Example of correct expression: ((a+b)/5-d).
    //Example of incorrect expression: )(a+b)).  

    class CheckBrackets
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some math expression:");
            string expression = Console.ReadLine();

            bool isValid = IsValidExpression(expression);

            Console.WriteLine(isValid ? "Valid expression" : "Invalid expression");
        }

        private static bool IsValidExpression(string expression)
        {
            bool isValid = true;

            StringBuilder brackets = new StringBuilder();
            foreach (var ch in expression)
            {
                if (ch == '(')
                {
                    brackets.Append('(');
                }

                if (ch == ')')
                {
                    if (brackets.Length > 0)
                    {
                        if (brackets[brackets.Length - 1] == '(')
                        {
                            brackets.Remove(brackets.Length - 1, 1);
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (brackets.Length != 0)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
