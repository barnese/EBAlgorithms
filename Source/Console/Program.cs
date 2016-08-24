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

            graph.AddEdge('a', 'b');
            graph.AddEdge('a', 'e');
            graph.AddEdge('b', 'f');
            graph.AddEdge('c', 'g');
            graph.AddEdge('d', 'e');
            graph.AddEdge('d', 'h');
            graph.AddEdge('e', 'h');
            graph.AddEdge('f', 'i');
            graph.AddEdge('f', 'j');
            graph.AddEdge('f', 'g');
            graph.AddEdge('g', 'j');
            graph.AddEdge('h', 'i');

            var result = "";

            foreach (var v in graph.DepthFirstSearch('a')) {
                result += v.ToString();
            }

            Console.WriteLine("Depth-first search = {0}", result);

            //Assert.Equal("abfgcjihde", result);
        }

        public static void CompareSortAlgorithms() {
            var comparer = new CompareSortAlgorithms();
            comparer.CompareAndPrintOutput();
        }
    }
}
