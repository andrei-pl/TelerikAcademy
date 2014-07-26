using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Multiply : ICalculate
    {
        public double calculate(double a, double b)
        {
            Console.WriteLine("Called Multiply's calculate");
            return a * b;
        }
    }
}
