namespace StrategyPattern
{
    using System;

    class Subtract : ICalculate
    {
        public double calculate(double a, double b)
        {
            Console.WriteLine("Called Subtract's calculate");
            return a - b;
        }
    }
}
