using System;

namespace _01.HelloName
{
    //Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). Write a program to test this method.

    class HelloName
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            PrintHello(name);
        }

        static void PrintHello(string name)
        {
            Console.WriteLine("Hello, " + name);
        }
    }
}
