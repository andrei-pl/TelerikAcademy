using System;
using System.Collections.Generic;

namespace _05.Generic
{
    class GenericList<T>
    {
        //5. Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
        //Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
        //Implement methods for adding element, accessing element by index, removing element by index, 
        //inserting element at given position, clearing the list, finding element by its value and ToString(). 
        //Check all input parameters to avoid accessing elements at invalid positions.

        private T[] array;
        public int Capacity { get; private set; }

        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
            }
        }

        public GenericList()
        {
            Capacity = 1;
            Count = 0;
            array = new T[Capacity];
        }

        public GenericList(int n, params T[] list)
        {
            Capacity = n;
            while (Capacity < list.Length)
            {
                Capacity *= 2;
            }
            array = new T[Capacity];

            for (int i = 0; i < list.Length; i++)
            {
                array[i] = list[i];
            }
            Count = list.Length;
        }

        public void Add(T item)
        {
            ArrayGrow();
            array[Count] = item;
            Count++;
        }

        public void Remove(int index)
        {
            array[index] = default(T);
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
                array[i + 1] = default(T);
            }
            Count--;
        }

        public void Insert(int index, T element)
        {
            ArrayGrow();
            for (int i = Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = element;
            Count++;
        }

        public void Clear()
        {
            array = new T[1];
            Capacity = 1;
            Count = 0;
        }

        public int Find(T element)
        {
            return Array.IndexOf(array, element);
        }

        public T this[uint index]
        {
            get
            {
                if (index >= this.Count - 1)
                    throw new IndexOutOfRangeException();

                return array[index];
            }
        }

        public override string ToString()
        {
            if (this.Count == 0)
            {
                return "Empty list.";
            }

            string[] info = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                info[i] = String.Format("{0}: {1}", i, this.array[i].ToString());
            }

            return String.Join(Environment.NewLine, info);
        }

        //6. Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.

        private void ArrayGrow()
        {
            if (Count == Capacity)
            {
                Capacity *= 2;
                T[] newArray = new T[Capacity];
                array.CopyTo(newArray, 0);
                array = newArray;
            }
        }

        //7. Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. 
        //You may need to add a generic constraints for the type T.

        public T Min()
        {
            T max = array[0];
            for (int i = 1; i < Count; i++)
            {
                if (max < (dynamic)array[i])
                {
                    max = array[i];
                }
            }
            return max;
        }

        public T Max()
        {
            T min = array[0];
            for (int i = 1; i < Count; i++)
            {
                if (min > (dynamic)array[i])
                {
                    min = array[i];
                }
            }
            return min;
        }

    }
}
