namespace _1.SelectionSorter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            if (collection.Count == 0)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be empty!");
            }

            for (int j = 0; j < collection.Count - 1; j++)
            {
                int iMin = j;

                for (int i = j + 1; i < collection.Count; i++)
                {
                    if (collection[i].CompareTo(collection[iMin]) < 0)
                    {
                        iMin = i;
                    }
                }

                if (iMin != j)
                {
                    Swap(collection, j, iMin);
                }
            }
        }

        private static void Swap(IList<T> newCollection, int j, int iMin)
        {
            T swapEllement = newCollection[iMin];
            newCollection[iMin] = newCollection[j];
            newCollection[j] = swapEllement;
        }
    }
}
