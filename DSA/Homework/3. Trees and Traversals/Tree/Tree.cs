/*
 * 1. You are given a tree of N nodes represented as a set of N-1 pairs 
 * of nodes (parent node, child node), each in the range (0..N-1). 
 * Example: 
 * 7 
 * 2 4 
 * 3 2 
 * 5 0 
 * 3 5 
 * 5 6 
 * 5 1 
 * Write a program to read the tree and find: 
 * a) the root node 
 * b) all leaf nodes 
 * c) all middle nodes 
 * d) the longest path in the tree 
 * e) * all paths in the tree with given sum S of their nodes 
 * f) * all subtrees with given sum S of their nodes 
 */

using System;
using System.Collections.Generic;

namespace TreesAndTraversals
{
    class Tree
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[N];

            for (int i = 0; i < N; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < N - 1; i++)
            {
                string inputEdge = Console.ReadLine();
                string[] edges = inputEdge.Split(' ');

                int parentId = int.Parse(edges[0]);
                int childId = int.Parse(edges[1]);

                nodes[parentId].Children.Add(nodes[childId]);
                nodes[childId].HasParent = true;
            }

            // 1. Find the root
            var root = FindRoot(nodes);
            Console.WriteLine("The root of the tree is: {0}", root.Value);

            // 2. Find all leafs
            var leafs = FindAllLeafs(nodes);
            Console.Write("Leafs: ");
            foreach (var leaf in leafs)
            {
                Console.Write("{0}, ", leaf.Value);
            }
            Console.WriteLine();

            // 3. Find all middle nodes
            var middleNodes = FindAllMiddleNodes(nodes);
            Console.Write("Middle nodes: ");
            foreach (var node in middleNodes)
            {
                Console.Write("{0}, ", node.Value);
            }
            Console.WriteLine();

            // 4. Find the longest path from the root
            var longestPath = FindLongestPath(FindRoot(nodes));
            Console.WriteLine("Number of levels: {0}", longestPath + 1);
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static List<Node<int>> FindAllLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();

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
            var isChild = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    isChild[child.Value] = true;
                }
            }

            for (int i = 0; i < isChild.Length; i++)
            {
                if (!isChild[i])
                {
                    return nodes[i];
                }
            }

            return null;
        }
    }
}
