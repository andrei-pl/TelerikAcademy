using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.NumberToText
{
    class NumberToText
    {
        static void Main(string[] args)
        {
            Console.Write("Enter some integer between 0 and 999: ");
            int someValue = int.Parse(Console.ReadLine());

            if (someValue >= 0 && someValue <= 999)
            {
                Console.WriteLine("You entered the number:");

                if (someValue == 0)
                {
                    Console.Write("Zero");
                }

                switch (someValue / 100)                //that we see if the number is more than 100
                {
                    case 1:
                        Console.Write("One hundred ");
                        break;
                    case 2:
                        Console.Write("Two hundred ");
                        break;
                    case 3:
                        Console.Write("Three hundred ");
                        break;
                    case 4:
                        Console.Write("Four hundred ");
                        break;
                    case 5:
                        Console.Write("Five hundred ");
                        break;
                    case 6:
                        Console.Write("Six hundred ");
                        break;
                    case 7:
                        Console.Write("Seven hundred ");
                        break;
                    case 8:
                        Console.Write("Eight hundred ");
                        break;
                    case 9:
                        Console.Write("Nine hundred ");
                        break;
                }

                if (someValue > 100 && (someValue % 100) > 0)  //if the number has values between 1 and 99 we add the word "and"
                {
                    Console.Write("and ");
                }

                if (someValue % 100 >= 10 && (someValue % 100) < 20) //check that the number is between 10 and 19
                {
                    switch (someValue % 100)
                    {
                        case 10:
                            Console.Write("ten");
                            break;
                        case 11:
                            Console.Write("eleven");
                            break;
                        case 12:
                            Console.Write("twelve");
                            break;
                        case 13:
                            Console.Write("thirteen");
                            break;
                        case 14:
                            Console.Write("fourteen");
                            break;
                        case 15:
                            Console.Write("fifteen");
                            break;
                        case 16:
                            Console.Write("sixteen");
                            break;
                        case 17:
                            Console.Write("seventeen");
                            break;
                        case 18:
                            Console.Write("eighteen");
                            break;
                        case 19:
                            Console.Write("nineteen");
                            break;
                    }
                }
                else                                   //write the numbers between 0 and 99
                {
                    switch ((someValue % 100) / 10)
                    {
                        case 2:
                            Console.Write("twenty ");
                            break;
                        case 3:
                            Console.Write("thirty ");
                            break;
                        case 4:
                            Console.Write("fourty ");
                            break;
                        case 5:
                            Console.Write("fifty ");
                            break;
                        case 6:
                            Console.Write("sixty ");
                            break;
                        case 7:
                            Console.Write("seventy ");
                            break;
                        case 8:
                            Console.Write("eighty ");
                            break;
                        case 9:
                            Console.Write("ninety ");
                            break;
                    }

                    switch (someValue % 10)
                    {
                        case 1:
                            Console.Write("one");
                            break;
                        case 2:
                            Console.Write("two");
                            break;
                        case 3:
                            Console.Write("three");
                            break;
                        case 4:
                            Console.Write("four");
                            break;
                        case 5:
                            Console.Write("five");
                            break;
                        case 6:
                            Console.Write("six");
                            break;
                        case 7:
                            Console.Write("seven");
                            break;
                        case 8:
                            Console.Write("eight");
                            break;
                        case 9:
                            Console.Write("nine");
                            break;
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("You entered wrong number.");
            }
        }
    }
}
