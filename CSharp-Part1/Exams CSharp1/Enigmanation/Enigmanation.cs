using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigmanation
{
    class Enigmanation
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            int i = 0;
            char symbol = expression[i];
            double firstNumber = 0;
            char innerOp = '+';
            char op = '+';
            double result = 0;
            bool isInParenthesis = false;

            while (symbol != '=')
            {
                if (symbol == '(')
                {
                    isInParenthesis = true;
                    i++;
                    symbol = expression[i];
                    continue;
                }
                if (symbol == ')')
                {
                    switch (op)
                    {
                        case '+': result += firstNumber;
                            break;
                        case '-': result -= firstNumber;
                            break;
                        case '*': result *= firstNumber;
                            break;
                        case '%': result %= firstNumber;
                            break;
                    }

                    firstNumber = 0;
                    innerOp = '+';
                    isInParenthesis = false;
                    i++;
                    symbol = expression[i];
                    continue;
                }

                if (isInParenthesis)
                {
                    switch (symbol)
                    {
                        case '+': innerOp = '+';
                            break;
                        case '-': innerOp = '-';
                            break;
                        case '*': innerOp = '*';
                            break;
                        case '%': innerOp = '%';
                            break;
                    }

                    if (char.IsDigit(symbol))
                    {
                        switch (innerOp)
                        {
                            case '+': firstNumber += symbol - '0';
                                break;
                            case '-': firstNumber -= symbol - '0';
                                break;
                            case '*': firstNumber *= symbol - '0';
                                break;
                            case '%': firstNumber %= symbol - '0';
                                break;
                        }
                    }
                }
                else
                {
                    switch (symbol)
                    {
                        case '+': op = '+';
                            break;
                        case '-': op = '-';
                            break;
                        case '*': op = '*';
                            break;
                        case '%': op = '%';
                            break;
                    }

                    if (char.IsDigit(symbol))
                    {
                        switch (op)
                        {
                            case '+': result += symbol - '0';
                                break;
                            case '-': result -= symbol - '0';
                                break;
                            case '*': result *= symbol - '0';
                                break;
                            case '%': result %= symbol - '0';
                                break;
                        }
                    }
                }
                i++;
                symbol = expression[i];
            }

            Console.WriteLine("{0:0.000}", result);
        }
    }
}
