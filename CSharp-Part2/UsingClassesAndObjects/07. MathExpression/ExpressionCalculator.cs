using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MathExpression
{
    class ExpressionCalculator
    {
        public static List<char> bracketsOrComma = new List<char>{ '(', ')' , ','};
        public static List<char> arithmeticalOperations = new List<char> { '+', '-', '*', '/' };
        public static List<string> functions = new List<string> { "ln", "pow", "sqrt" };
        
        //Separate the string and making a list of it separated by numbers, function names, operators and brackets
        public static List<string> SeparateTokens(string input)
        {
            var result = new List<string>();
            var number = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if ((!char.IsDigit(input[i]) && input[i] != '.') && number.Length != 0)     //if number is not empty and the current element is not digit 
                {                                                                               //than put the number in the list
                    result.Add(number.ToString());
                    number.Clear();
                }

                if (input[i] == '-' && (i == 0 || input[i - 1] == ',' || input[i - 1] == '('))
                {
                    number.Append('-');
                }
                else if(char.IsDigit(input[i]) || input[i] == '.')
                {
                    number.Append(input[i]);
                }
                else if (bracketsOrComma.Contains(input[i]) || arithmeticalOperations.Contains(input[i]))
                {
                    result.Add(input[i].ToString());
                }
                else if (i + 1 < input.Length && input.Substring(i, 2).ToLower() == "ln")
                {
                    result.Add("ln");
                    i++;
                }
                else if (i + 2 < input.Length && input.Substring(i, 3).ToLower() == "pow")
                {
                    result.Add("pow");
                    i += 2;
                }
                else if (i + 3 < input.Length && input.Substring(i, 4).ToLower() == "sqrt")
                {
                    result.Add("sqrt");
                    i += 3;
                }
                else
                {
                    throw new ArgumentException("Invalid expression!");
                }
            }
            if (number.Length != 0)
            {
                result.Add(number.ToString());
                number.Clear();
            }

            return result;
        }

        //Giving precedence of operators
        public static int Precedence(string arithmeticOperator)
        {
            if (arithmeticOperator == "+" || arithmeticOperator == "-")
            {
                return 1;
            }
            return 2;
        }
        
        //Shunting-yard algorithm
        public static Queue<string> ConvertToReversePolishNotation(List<string> token)
        {
            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < token.Count; i++)
            {
                var currentToken = token[i];
                double number;

                if (double.TryParse(currentToken, out number))
                {
                    queue.Enqueue(currentToken);
                }
                else if (functions.Contains(currentToken))
                {
                    stack.Push(currentToken);
                }
                else if (currentToken == ",")
                {
                    if (!stack.Contains("("))
                    {
                        throw new ArgumentException("Invalid brackets or function separator!");
                    }
                    while (stack.Peek() != "(")
                    {
                        queue.Enqueue(stack.Pop());
                    }
                }
                else if (arithmeticalOperations.Contains(currentToken[0]))
                {
                    while (stack.Count != 0 && arithmeticalOperations.Contains(stack.Peek()[0]) && Precedence(currentToken) <= Precedence(stack.Peek()))
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Push(currentToken);
                }
                else if (currentToken == "(")
                {
                    stack.Push("(");
                }
                else if (currentToken == ")")
                {
                    if (!stack.Contains("("))
                    {
                        throw new ArgumentException("Invalid expression! Missing left bracket!");
                    }
                    while (stack.Peek() != "(")
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Pop();
                    if (stack.Count != 0 && functions.Contains(stack.Peek()))
                    {
                        queue.Enqueue(stack.Pop());
                    }
                }
            }

            while (stack.Count != 0)
            {
                if (bracketsOrComma.Contains(stack.Peek()[0]))
                {
                    throw new ArgumentException("Invalid expression! Missmatched brackets!");
                }
                queue.Enqueue(stack.Pop());
            }

            return queue;
        }

        //Calculation through reverse Polish notation
        public static double ConvertFromRPN(Queue<string> queue)
        {
            Stack<double> stack = new Stack<double>();

            while (queue.Count != 0)
            {
                string currentToken = queue.Dequeue();
                double number;

                if (double.TryParse(currentToken, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    if (arithmeticalOperations.Contains(currentToken[0]) || functions.Contains(currentToken))
                    {
                        if (arithmeticalOperations.Contains(currentToken[0]) || currentToken == "pow")
                        {
                            if (stack.Count < 2)
                            {
                                throw new ArgumentException("Invalid number of arguments!");
                            }

                            double firstValue = stack.Pop();
                            double secondValue = stack.Pop();

                            if (currentToken == "+")
                            {
                                stack.Push(secondValue + firstValue);
                            }
                            if (currentToken == "-")
                            {
                                stack.Push(secondValue - firstValue);
                            }
                            if (currentToken == "*")
                            {
                                stack.Push(secondValue * firstValue);
                            }
                            if (currentToken == "/")
                            {
                                stack.Push(secondValue / firstValue);
                            }
                            if (currentToken == "pow")
                            {
                                stack.Push(Math.Pow(secondValue, firstValue));
                            }
                        }
                        else
                        {
                            if (stack.Count < 1)
                            {
                                throw new ArgumentException("Invalid number of arguments!");
                            }

                            double value = stack.Pop();

                            if (currentToken == "ln")
                            {
                                stack.Push(Math.Log(value));
                            }
                            if (currentToken == "sqrt")
                            {
                                stack.Push(Math.Sqrt(value));
                            }
                        }
                    }
                }
            }

            if (stack.Count != 1)
            {
                throw new ArgumentException("Invalid expression!");
            }
            return stack.Pop();
        }

        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
           
            Console.WriteLine("Enter arithmetical expression (\"end\" to finish):");
            string input = Console.ReadLine().Trim();
           
            while(input.ToLower() != "end")
            {
                string trimedInput = input.Replace(" ", String.Empty);

                if (!string.IsNullOrEmpty(trimedInput))
                {
                    var separatedTokens = SeparateTokens(trimedInput.ToLower());
                    var reversePolishNotashion = ConvertToReversePolishNotation(separatedTokens);
                    var reversedFromRPN = ConvertFromRPN(reversePolishNotashion);
                    Console.WriteLine(reversedFromRPN);
                }

                input = Console.ReadLine().Trim();
            }
        }
    }
}
