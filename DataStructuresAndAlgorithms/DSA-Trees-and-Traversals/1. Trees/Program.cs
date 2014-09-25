namespace _1.Trees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), each in the range (0..N-1). 
    /// Write a program to read the tree and find:
    /// a) the root node
    /// b) all leaf nodes
    /// c) all middle nodes
    /// d) the longest path in the tree
    /// e) * all paths in the tree with given sum S of their nodes
    /// f) * all subtrees with given sum S of their nodes
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[N];

            for (int i = 0; i < N; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 1; i <= N - 1; i++)
            {
                var pair = Console.ReadLine().Split(' ');
                int parent = int.Parse(pair[0]);
                int child = int.Parse(pair[1]);
                nodes[parent].Children.Add(nodes[child]);
            }
            // a) 
            var root = FindRoot(nodes);
            Console.WriteLine("The root is: {0}", root.Value);

            // b)
            var leafNodes = FindLeafNodes(nodes);

            Console.Write("Leaf nodes: ");

            foreach (var leaf in leafNodes)
            {
                Console.Write(leaf.Value + " ");
            }
            Console.WriteLine();

            // c)
            var middleNodes = FindMiddleNodes(nodes);

            Console.Write("Middle nodes: ");

            foreach (var middleNode in middleNodes)
            {
                Console.Write(middleNode.Value + " ");
            }
            Console.WriteLine();

            // d)
            Console.WriteLine("The longest path is : {0}", FindLongestPath(FindRoot(nodes)));

            // e)
            Console.WriteLine("Longest path with sum of 9: ");
            PrintAllPathsWithSumS(root, 9, root.Value, root.Value.ToString());

            // f)
            Console.WriteLine("Subtrees with sum 6 of their nodes: ");
            var subTrees = new List<Node<int>>();

            FindAllSubTreesWithSumS(root, subTrees, 6, root.Value);
            Console.WriteLine(subTrees.Count);
        }

        private static void FindAllSubTreesWithSumS(Node<int> root, List<Node<int>> subTrees, int sum, int currentSum)
        {
            if (root.Children.Count != 0)
            {
                foreach (var child in root.Children)
                {
                    currentSum += CheckSubTreeSum(child, child.Value);
                    if (currentSum == sum)
                    {
                        subTrees.Add(child);
                    }

                    FindAllSubTreesWithSumS(child, subTrees, sum, child.Value);
                }
            }
        }

        private static int CheckSubTreeSum(Node<int> root, int sum)
        {
            if (root.Children.Count == 0)
            {
                return root.Value;
            }

            foreach (var child in root.Children)
            {
                sum += CheckSubTreeSum(child, child.Value);  //thus will never count leafes as a subTree,
            }                                                //because of the difference in the end result -> sum + same value

            return sum;
        }



        private static void PrintAllPathsWithSumS(Node<int> root, int s, int sum, string path)
        {
            if (sum == s)
            {
                Console.WriteLine(path);
            }
            else
            {
                foreach (var child in root.Children)
                {
                    PrintAllPathsWithSumS(child, s, sum + child.Value, path + " -> " + child.Value);
                }
            }
        }

        private static int FindLongestPath(Node<int> node)
        {
            if (node.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;

            foreach (var child in node.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(child));
            }

            return maxPath + 1;
        }

        private static List<Node<int>> FindMiddleNodes(Node<int>[] nodes)
        {
            var middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count != 0)
                {
                    middleNodes.Add(node);
                }
            }

            var root = FindRoot(nodes);
            middleNodes.Remove(root);

            return middleNodes;
        }

        private static List<Node<int>> FindLeafNodes(Node<int>[] nodes)
        {
            var leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static Node<int> FindRoot(Node<int>[] nodes)
        {
            bool[] hasParent = new bool[nodes.Length];

            foreach (var item in nodes)
            {
                foreach (var child in item.Children)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("nodes", "The three has no root");
        }
    }
}
