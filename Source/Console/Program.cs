using System;
using EBAlgorithms;
using EBAlgorithms.DataStructures;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace EBAlgorithmsConsole {
    public class Program {
        public static void Main(string[] args) {
            //CompareSortAlgorithms();

            var graph = new Graph<char>(GraphType.Directed);

            graph.AddEdge('a', 'b', 10);
            graph.AddEdge('a', 'c', 3);
            graph.AddEdge('b', 'c', 1);
            graph.AddEdge('b', 'd', 2);
            graph.AddEdge('c', 'b', 4);
            graph.AddEdge('c', 'd', 8);
            graph.AddEdge('c', 'e', 2);
            graph.AddEdge('d', 'e', 7);
            graph.AddEdge('e', 'd', 9);

            graph.Describe();

            var result = "";

            foreach (var v in graph.DepthFirstSearch('a')) {
                result += v.ToString();
            }

            Console.WriteLine("Depth-first search: {0}", result);

            result = "";

            foreach (var v in graph.BreadthFirstSearch('a')) {
                result += v.ToString();
            }

            Console.WriteLine("Breadth-first search: {0}", result);
        }

        public static void CompareSortAlgorithms() {
            var comparer = new CompareSortAlgorithms();
            comparer.CompareAndPrintOutput();
        }
    }
}
