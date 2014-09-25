namespace _4.SortableCollection
{
    using System;
    using System.Collections.Generic;

    using _1.SelectionSorter;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var searchedItem in this.Items)
            {
                if (searchedItem.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            // recursion
            return BinarySearchRecursion(item, 0, this.Items.Count - 1);

            //iterative binary search
            //int left = 0; 
            //int right = this.Items.Count - 1;

            //while (left <= right)
            //{
            //    int middle = (left + right) / 2;
            //    if (this.Items[middle].Equals(item))
            //    {
            //        return true;
            //    }
            //    else if (this.Items[middle].CompareTo(item) > 0)
            //    {
            //        right = middle - 1;
            //    }
            //    else
            //    {
            //        left = middle + 1;
            //    }
            //}
            //return false;
        }

        private bool BinarySearchRecursion(T item, int startIndex, int endIndex)
        {
            if(endIndex < startIndex)
            {
                return false;
            }

            int middle = (endIndex + startIndex) / 2;

            if(this.Items[middle].CompareTo(item) > 0)
            {
                return BinarySearchRecursion(item, startIndex, middle - 1);
            }
            else if(this.Items[middle].CompareTo(item) < 0)
            {
                return BinarySearchRecursion(item, middle + 1, endIndex);
            }

            return true;
        }

        public void Shuffle()
        {
            Random randomGenerator = new Random();

            for (int i = this.items.Count - 1; i > 0; i--)
            {
                int randomIndex = randomGenerator.Next(0, i);

                T swapValue = this.items[i];
                this.items[i] = this.items[randomIndex];
                this.items[randomIndex] = swapValue;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            Console.WriteLine(string.Join(" ", items));

            Console.WriteLine();
        }
    }
}
