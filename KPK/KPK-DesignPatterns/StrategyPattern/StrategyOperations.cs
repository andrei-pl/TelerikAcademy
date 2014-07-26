using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class StrategyOperations
    {
        ICalculate operation;

        public StrategyOperations(ICalculate operation)
        {
            this.operation = operation;
        }

        public double calculate(double a, double b)
        {
            return this.operation.calculate(a, b);
        }
    }
}
