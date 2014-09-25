namespace _4.SortableCollection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using _1.SelectionSorter;
    using _2.QuickSorter;
    using _3.MergeSorter;

    class Program
    {
        static void Main(string[] args)
        {
            var mergeSorter = new MergeSorter<int>();
            var collection = new List<int> { 23, 45, 12, 3, 56, 78, 14, 1 };
            var collectionForSearch = new SortableCollection<int>(collection);
            collectionForSearch.Sort(mergeSorter);

            Console.WriteLine(collectionForSearch.LinearSearch(45));
            Console.WriteLine(collectionForSearch.LinearSearch(7));
            Console.WriteLine(collectionForSearch.BinarySearch(1));
            Console.WriteLine(collectionForSearch.BinarySearch(6));
            Console.WriteLine();
            Console.WriteLine("Shuffle: ");
            collectionForSearch.Shuffle();
            Console.WriteLine(string.Join(" ", collectionForSearch.Items));
            Console.WriteLine();
            Console.WriteLine("Shuffle again: ");
            collectionForSearch.Shuffle();
            Console.WriteLine(string.Join(" ", collectionForSearch.Items));
        }
    }
}
