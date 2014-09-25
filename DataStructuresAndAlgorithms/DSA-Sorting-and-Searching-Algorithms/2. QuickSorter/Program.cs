﻿namespace _2.QuickSorter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> unsortedList= new List<int>{23, 45, 12, 3, 56, 78, 14, 1};
            Console.WriteLine("Unsorted list: " + string.Join(", ", unsortedList));

            var quickSort = new QuickSorter<int>();
            quickSort.Sort(unsortedList);

            Console.WriteLine("Sorted list: " + string.Join(", ", unsortedList));
        }
    }
}
