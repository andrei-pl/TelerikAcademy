using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BinarySearch
{
    /// <summary>
    /// 06. Define the data structure binary search tree with operations for "adding new element", "searching element" and "deleting elements". 
    /// It is not necessary to keep the tree balanced. Implement the standard methods from System.Object – ToString(), Equals(…), GetHashCode() 7
    /// and the operators for comparison  == and !=. Add and implement the ICloneable interface for deep copy of the tree. 
    /// Remark: Use two types – structure BinarySearchTree (for the tree) and class TreeNode (for the tree elements). 
    /// Implement IEnumerable<T> to traverse the tree.
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> tree1 = new BinarySearchTree<int>();
            tree1.Add(11);
            tree1.Add(35);
            tree1.Add(7);
            tree1.Add(16);
            tree1.Add(23);
            tree1.Add(13);
            tree1.Add(17);

            //tree1.Remove(11);
            //tree1.Remove(7);
            //tree1.Remove(16);
            //tree1.Remove(23);
            //tree1.Remove(13);

            //Console.WriteLine(tree1);
            //Console.WriteLine(tree1.AsString(false));

            BinarySearchTree<int> tree2 = new BinarySearchTree<int>();
            tree2.Add(11);
            tree2.Add(35);
            tree2.Add(7);
            tree2.Add(16);
            tree2.Add(23);
            tree2.Add(13);
            tree2.Add(17);

            Console.WriteLine(tree2);

            BinarySearchTree<int> tree3 = tree2.Clone();

            Console.WriteLine(tree3);
            Console.WriteLine(tree3 == tree2);

            tree2.Remove(23);
            tree2.Add(2323);

            Console.WriteLine(tree2);
            Console.WriteLine(tree3);

            foreach (int item in tree2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
