namespace _11.LinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implement the data structure linked list. Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>). 
    /// Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();

            list.AddLast(1);
            Console.WriteLine(list);

            list.AddLast(2);
            Console.WriteLine(list);

            list.AddLast(3);
            Console.WriteLine(list);

            list.AddFirst(-1);
            Console.WriteLine(list);

            list.AddFirst(-2);
            Console.WriteLine(list);

            list.AddFirst(-3);
            Console.WriteLine(list);

            Console.WriteLine("Remove First: {0}", list.RemoveFirst().Value);
            Console.WriteLine("Remove Last: {0}", list.RemoveLast().Value);
            Console.WriteLine(list);

            Console.WriteLine("Min: {0}; Max: {1}", list.Min(), list.Max());
            Console.WriteLine("Contains 2: {0}", list.Contains(2));
            Console.WriteLine("Count: {0}", list.Count);
        }
    }
}
