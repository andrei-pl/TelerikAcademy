using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            StrategyOperations context = new StrategyOperations(new Add());
            double result = context.calculate(2.5, 3.6);
            Console.WriteLine(result);

            context = new StrategyOperations(new Subtract());
            result = context.calculate(2.5, 3.6);
            Console.WriteLine(result);
            
            context = new StrategyOperations(new Multiply());
            result = context.calculate(2.5, 3.6);
            Console.WriteLine(result);
            
            context = new StrategyOperations(new Divide());
            result = context.calculate(2.5, 3.6);
            Console.WriteLine(result);
        }
    }
}
