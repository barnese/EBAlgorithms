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
            //HashMapTests();
            //CatalanNumbersTest();
            //TestLucasLehmer();
            //TestStringPermutations();
            //TestGraph();
            TestHeap();
        }

        public static void CompareSortAlgorithms() {
            var comparer = new CompareSortAlgorithms();
            comparer.CompareAndPrintOutput();
        }

        public static void HashMapTests() {
            Console.OutputEncoding = Encoding.Unicode;

            var words = FileHelpers.SplitFileIntoWords("LoremIpsum.txt");

            var hashmap = new HashMap<string, int>(words.Length);

            foreach (var word in words) {
                var w = word.ToLower();             
                if (hashmap.ContainsKey(w)) {
                    hashmap[w]++;
                } else {
                    hashmap.Put(w, 1);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Total words  = {0}", words.Length);
            Console.WriteLine("Unique words = {0}", hashmap.Count);
        }

        public static void CatalanNumbersTest() {
            for (var i = 0; i < 15; i++) {
                Console.Write("{0} ", CatalanNumbers.GetCatalan(i));
            }

            Console.WriteLine();
        }

        public static void TestHeap() {
            var heap = new Heap<int>(new List<int> { 4, 6, 1, 2, 5, 3 }, HeapType.MinHeap);
            Console.WriteLine(heap.Describe());
        }

        public static void TestGraph() {
            var graph = new Graph<char>(GraphType.Directed);

            graph.AddEdge('a', 'b');
            graph.AddEdge('a', 'd');
            graph.AddEdge('a', 'e');
            graph.AddEdge('b', 'd');
            graph.AddEdge('b', 'c');
            graph.AddEdge('d', 'c');
            graph.AddEdge('d', 'a');
            graph.AddEdge('d', 'e');
            graph.AddVertex('c');
            graph.AddVertex('e');

            Console.WriteLine("Breadth-first search:");
            foreach (var v in graph.BreadthFirstSearch('a')) {
                Console.Write("{0} ", v);
            }

            //Console.WriteLine("\nDepth-first search:");            
            //foreach (var v in graph.DepthFirstSearch(2)) {
            //    Console.Write("{0} ", v);
            //}

            //Console.WriteLine("\nTopological sort:");
            //foreach (var vertex in graph.TopologicalSort(2)) {
            //    Console.Write("{0} ", vertex);
            //}

            //Console.WriteLine("\n");

            //graph.Describe();
        }

        public static void TestLucasLehmer() {
            for (var i = 0; i < 10000; i++) {
                if (LucasLehmerTest.IsPrime(i)) {
                    Console.Write("{0} ", i);
                }
            }

            Console.WriteLine();
        }

        public static void TestStringPermutations() {
            var str = "cat";
            var perms = str.FindPermutations();

            foreach (var perm in perms) {
                Console.Write("{0} ", perm);
            }

            Console.WriteLine("\nNumber of perms = {0}", perms.Count);
        }
    }
}
