namespace _2.QuickSorter
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;

    using _1.SelectionSorter;

    class QuickSorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            int pivotNewIndex = this.Partition(collection, leftIndex, rightIndex);
            QuickSort(collection, leftIndex, pivotNewIndex - 1);
            QuickSort(collection, pivotNewIndex + 1, rightIndex);
        }

        private int Partition(IList<T> collection, int leftIndex, int rightIndex)
        {
            T pivotValue = collection[rightIndex];

            int newIndex = leftIndex;

            for (int i = leftIndex; i < rightIndex; i++)
            {
                if (collection[i].CompareTo(pivotValue) < 0)
                {
                    pivotValue = Swap(collection, pivotValue, newIndex, i);

                    newIndex++;
                }
            }

            pivotValue = Swap(collection, pivotValue, newIndex, rightIndex);

            return newIndex;
        }

        private static T Swap(IList<T> collection, T swapValue, int newIndex, int i)
        {
            swapValue = collection[i];
            collection[i] = collection[newIndex];
            collection[newIndex] = swapValue;
            return swapValue;
        }
        //public IList<T> Sort(IList<T> collection)  // second variant
        //{
        //    if (collection == null)
        //    {
        //        throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
        //    }

        //    if (collection.Count <= 1)
        //    {
        //        return collection;
        //    }

        //    List<T> newCollection = new List<T>(collection);
        //    T pivot = newCollection[0];
        //    List<T> right = new List<T>();
        //    List<T> left = new List<T>();

        //    newCollection.Remove(pivot);

        //    foreach (var element in newCollection)
        //    {
        //        if (element.CompareTo(pivot) < 0)
        //        {
        //            right.Add(element);
        //        }
        //        else
        //        {
        //            left.Add(element);
        //        }
        //    }

        //    return Concatenate(Sort(right), new List<T> { pivot }, Sort(left));
        //}

        //private IList<T> Concatenate(IList<T> right, IList<T> pivot, IList<T> left)
        //{
        //    foreach (var element in pivot)
        //    {
        //        right.Add(element);
        //    }

        //    foreach (var element in left)
        //    {
        //        right.Add(element);
        //    }
        //    return right;
        //}
    }
}
