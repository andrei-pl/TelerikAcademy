﻿namespace MinimumSpanningTree_Cables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    /// <summary>
    /// You are given a cable TV company. The company needs to lay cable to a new neighborhood (for every house). 
    /// If it is constrained to bury the cable only along certain paths, then there would be a graph representing which points are connected by those paths. 
    /// But the cost of some of the paths is more expensive because they are longer. If every house is a node and every path from house to house is an edge, 
    /// find a way to minimize the cost for cables.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Edge> priority = new SortedSet<Edge>();
            int numberOfNodes = 8;
            bool[] used = new bool[numberOfNodes + 1];
            List<Edge> mpdNodes = new List<Edge>();
            List<Edge> edges = new List<Edge>();
            InitializeGraph(edges);

            Console.WriteLine("The paths from house to house are:");

            //adding edges that connect the node 1 with all the others - 2, 3, 4
            for (int i = 0; i < edges.Count; i++)
            {
                Console.WriteLine("{0}", edges[i]);
                if (edges[i].StartNode == edges[0].StartNode)
                {
                    priority.Add(edges[i]);
                }
            }
            used[edges[0].StartNode] = true;

            FindMinimumSpanningTree(used, priority, mpdNodes, edges);

            PrintMinimumSpanningTree(mpdNodes);
        }

        private static void PrintMinimumSpanningTree(List<Edge> mpdNodes)
        {
            Console.WriteLine("The minimum spanning tree to minimize the cabling expenses:");
            for (int i = 0; i < mpdNodes.Count; i++)
            {
                Console.WriteLine("{0}", mpdNodes[i]);
            }
        }

        private static void FindMinimumSpanningTree(bool[] used, SortedSet<Edge> priority, List<Edge> mpdEdges, List<Edge> edges)
        {
            while (priority.Count > 0)
            {
                Edge edge = priority.Min;
                priority.Remove(edge);

                if (!used[edge.EndNode])
                {
                    used[edge.EndNode] = true; //we "visit" this node
                    mpdEdges.Add(edge);
                    AddEdges(edge, edges, mpdEdges, priority, used);
                }
            }
        }

        private static void AddEdges(Edge edge, List<Edge> edges, List<Edge> mpd, SortedSet<Edge> priority, bool[] used)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (!mpd.Contains(edges[i]))
                {
                    if (edge.EndNode == edges[i].StartNode && !used[edges[i].EndNode])
                    {
                        priority.Add(edges[i]);
                    }
                }
            }
        }

        private static void InitializeGraph(List<Edge> edges)
        {
            edges.Add(new Edge(1, 3, 5));
            edges.Add(new Edge(1, 2, 4));
            edges.Add(new Edge(1, 4, 9));
            edges.Add(new Edge(2, 4, 2));
            edges.Add(new Edge(3, 4, 20));
            edges.Add(new Edge(3, 5, 7));
            edges.Add(new Edge(4, 5, 8));
            edges.Add(new Edge(4, 7, 6));
            edges.Add(new Edge(5, 6, 12));
            edges.Add(new Edge(6, 8, 2));
            edges.Add(new Edge(7, 8, 4));
        }
    }
}
