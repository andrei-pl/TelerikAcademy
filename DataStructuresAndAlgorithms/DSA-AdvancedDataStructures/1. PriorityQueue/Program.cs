namespace _1.PriorityQueue
{
    using System;

    /// <summary>
    /// Implement a class PriorityQueue<T> based on the data structure "binary heap".
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> heap = new PriorityQueue<int>(2);
            heap.Enqueue(1);
            heap.Enqueue(2);
            heap.Enqueue(3);
            heap.Enqueue(4);
            heap.Dequeue();
            heap.Enqueue(3);
            heap.Enqueue(5);
            Console.WriteLine(heap.Dequeue());
            heap.Print();
            heap.Enqueue(2);
            heap.Print();
        }
    }
}
