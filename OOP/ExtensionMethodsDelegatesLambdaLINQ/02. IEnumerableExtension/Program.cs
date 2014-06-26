using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IEnumerableExtension
{
    //02. Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Max: {0}", elements.Max<int>());
            Console.WriteLine("Min: {0}", elements.Min<int>());
            Console.WriteLine("Sum: {0}", elements.Sum<int>());
            Console.WriteLine("Product: {0}", elements.Product<int>());
            Console.WriteLine("Count: {0}", elements.Count<int>());
            Console.WriteLine("Average: {0}", elements.Average<int>());
        }
    }
}
