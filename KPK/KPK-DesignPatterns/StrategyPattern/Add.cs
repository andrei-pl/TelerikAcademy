namespace StrategyPattern
{
    using System;

    class Add : ICalculate
    {

        public double calculate(double a, double b)
        {
            Console.WriteLine("Called add's calculate");
            return a + b;
        }
    }
}
