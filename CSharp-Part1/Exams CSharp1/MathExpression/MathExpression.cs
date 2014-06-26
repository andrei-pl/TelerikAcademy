using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpression
{
    class MathExpression
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            decimal n = decimal.Parse(Console.ReadLine());
            decimal m = decimal.Parse(Console.ReadLine());
            decimal p = decimal.Parse(Console.ReadLine());

            decimal result = (decimal)(n * n + 1 / (m * p) + 1337) / (n - 128.523123123m * p) + (decimal)Math.Sin((double)Math.Truncate(m % 180));
            Console.WriteLine("{0:F6}",result);
        }
    }
}
