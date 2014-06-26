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
            int symbol = Console.Read();
            int operation = '+';
            decimal sum = 0;

            while (symbol != '=')
            {
                if (symbol == '(')
                {
                    decimal bracketsSum = 0;
                    int bracketsOperation = '+';

                    symbol = Console.Read();
                    while (symbol != ')')
                    {
                        if (symbol >= '0' && symbol <= '9')
                        {
                            switch (bracketsOperation)
                            {
                                case '+': bracketsSum += (symbol - 48); break;
                                case '-': bracketsSum -= (symbol - 48); break;
                                case '*': bracketsSum *= (symbol - 48); break;
                                case '%': bracketsSum %= (symbol - 48); break;
                            }
                        }
                        else
                        {
                            bracketsOperation = symbol;
                        }
                        symbol = Console.Read();
                    }
                    switch (operation)
                    {
                        case '+': sum += bracketsSum; break;
                        case '-': sum -= bracketsSum; break;
                        case '*': sum *= bracketsSum; break;
                        case '%': sum %= bracketsSum; break;
                    }
                    symbol = Console.Read();
                }
                else
                {
                    if (symbol >= '0' && symbol <= '9')
                    {
                        switch (operation)
                        {
                            case '+': sum += (symbol - 48); break;
                            case '-': sum -= (symbol - 48); break;
                            case '*': sum *= (symbol - 48); break;
                            case '%': sum %= (symbol - 48); break;
                        }
                    }
                    else
                    {
                        operation = symbol;
                    }
                    symbol = Console.Read();
                }
            }
            Console.WriteLine("{0:F3}",  sum);
            
            //Недовършена: Гледане за приоритет на операциите.

            //string mathExpression = Console.ReadLine();
            //mathExpression = mathExpression.Replace(" ", "");
            //mathExpression = mathExpression.Replace("=", "");

            //string operation = "";
            //bool isInBrackets = false;
            //int bracketsLength = 0;

            //for (int i = 0; i < mathExpression.Length; i++)
            //{
            //    int result = 0;

            //    int counter = 0;
            //    if (mathExpression[i] == '(')
            //    {
            //        //isInBrackets = true;
            //        int count = i + 1;
            //        string str1 = "";
            //        string str2 = "";
            //        string strOld = "(";
            //        while (mathExpression[count] != '%' && mathExpression[count] != ')')
            //        {
            //            str1 += mathExpression[count].ToString();
            //            strOld += mathExpression[count].ToString();
            //            count++;
            //        }
            //        double str1Double = Convert.ToDouble(str1);

            //        if (mathExpression[i] == '%')
            //        {
            //            strOld += '%';
            //            count++;
            //            while (mathExpression[count] != ')')
            //            {
            //                str2 += mathExpression[count].ToString();
            //                strOld += mathExpression[count].ToString();
            //                count++;
            //            }
            //            double str2Double = Convert.ToDouble(str2);
            //            str1 = Math.IEEERemainder(str1Double, str2Double).ToString();
            //        }
            //        //int resultRem = Convert.ToInt32(str1);
            //        mathExpression.Replace(strOld + ")", str1);

            //        counter++;
            //        count++;
            //    }
            //}
        }
    }
}
