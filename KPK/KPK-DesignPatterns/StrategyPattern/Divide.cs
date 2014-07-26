using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Divide : ICalculate
    {
        public double calculate(double a, double b)
        {
            Console.WriteLine("Called Divide's calculate");
            return a / b;
        }
    }
}
