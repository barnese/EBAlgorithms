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

            var graph = new Graph<char>(GraphType.Undirected);

            graph.AddEdge('a', 'b', 4);
            graph.AddEdge('a', 'c', 2);
            graph.AddEdge('b', 'c', 1);
            graph.AddEdge('b', 'd', 5);
            graph.AddEdge('c', 'd', 8);
            graph.AddEdge('c', 'e', 10);
            graph.AddEdge('d', 'e', 2);
            graph.AddEdge('d', 'z', 6);
            graph.AddEdge('e', 'z', 3);

            var result = "";

            foreach (var v in Dijkstra<char>.FindShortestPaths(graph, 'a')) {
                result += v.ToString();
            }

            Console.WriteLine("Dijkstra's shortest path: {0}", result);
        }

        public static void CompareSortAlgorithms() {
            var comparer = new CompareSortAlgorithms();
            comparer.CompareAndPrintOutput();
        }
    }
}
