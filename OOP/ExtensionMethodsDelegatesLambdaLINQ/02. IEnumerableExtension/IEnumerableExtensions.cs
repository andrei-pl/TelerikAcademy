using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IEnumerableExtension
{
    //02. Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

    public static class IEnumerableExtensions
    {
        public static decimal Sum<T>(this IEnumerable<T> souce) where T : struct, IComparable<T>, IConvertible
        {
            decimal sum = 0;
            foreach (T element in souce)
            {
                sum += (dynamic)element;
            }
            return sum;
        }

        public static decimal Product<T>(this IEnumerable<T> source) where T : struct, IConvertible, IComparable<T>
        {
            decimal product = 1;
            foreach (T element in source)
            {
                product = product * (dynamic)element;
            }
            return product;
        }

        public static T Min<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            T min = source.First();
            foreach (T element in source)
            {
                if (element.CompareTo(min) < 0)
                {
                    min = element;
                }
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            T max = source.First();
            foreach (T element in source)
            {
               if (element.CompareTo(max) > 0)
                {
                    max = element;
                }
            }

            return max;
        }

        public static decimal Average<T>(this IEnumerable<T> source) where T : struct, IConvertible, IComparable<T>
        {
            decimal sum = 0;
            int count = 0;
            foreach (T element in source)
            {
                sum = sum + (dynamic)element;
                count++;
            }
            return sum / count;
        }
    }
}
