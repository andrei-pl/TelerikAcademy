namespace _1.Trees
{
    using System;
    using System.Collections.Generic;
    
    internal class Node<T>
    {
        public T Value { get; set; }

        public List<Node<T>> Children;

        public Node(T value)
        {
            this.Children = new List<Node<T>>();
            this.Value = value;
        }
    }
}
