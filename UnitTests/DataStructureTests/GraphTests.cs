﻿using Xunit;
using EBAlgorithms.DataStructures;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class GraphTests {
        [Fact]
        public void TestUndirectedDFS() {
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

            Assert.Equal("abfgcjihde", result);
        }

        [Fact]
        public void TestDirectedDFS() {
            var graph = new Graph<char>(GraphType.Directed);

            graph.AddEdge('g', 'h');
            graph.AddEdge('a', 'b');
            graph.AddEdge('a', 'h');
            graph.AddEdge('b', 'c');
            graph.AddEdge('c', 'f');
            graph.AddEdge('d', 'b');
            graph.AddEdge('d', 'e');
            graph.AddEdge('e', 'f');
            graph.AddVertex('i');

            var result = "";

            foreach (var v in graph.DepthFirstSearch('a')) {
                result += v.ToString();
            }

            Assert.Equal("ghabcfdei", result);
        }

        [Fact]
        public void TestDirectedBFS() {
            var graph = new Graph<char>(GraphType.Directed);

            graph.AddEdge('a', 'b');
            graph.AddEdge('a', 'd');
            graph.AddEdge('a', 'e');
            graph.AddEdge('b', 'd');
            graph.AddEdge('b', 'c');
            graph.AddEdge('d', 'c');
            graph.AddEdge('d', 'a');
            graph.AddEdge('d', 'e');

            var result = "";

            foreach (var v in graph.BreadthFirstSearch('a')) {
                result += v.ToString();
            }

            Assert.Equal("abdec", result);
        }

        [Fact]
        public void TestUndirectedBFS() {
            var graph = new Graph<int>();

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 6);
            graph.AddEdge(4, 5);

            var expected = new List<int> { 0, 1, 2, 4, 3, 5, 6 };
            var result = graph.BreadthFirstSearch(0);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestDijkstraDirected() {
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

            var result = "";

            foreach (var v in Dijkstra<char>.FindShortestPaths(graph, 'a')) {
                result += v.ToString();
            }

            Assert.Equal("[a, 0][b, 7][c, 3][d, 9][e, 5]", result);
        }

        [Fact]
        public void TestDijkstraUndirected() {
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

            Assert.Equal("[a, 0][b, 3][c, 2][d, 8][e, 10][z, 13]", result);
        }

        [Fact]
        public void TestDijkstraDirectedWithTarget() {
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

            var result = "";

            foreach (var v in Dijkstra<char>.FindShortestPaths(graph, 'a', 'd')) {
                result += v.ToString();
            }

            Assert.Equal("[d, 9]", result);
        }

        [Fact]
        public void TestBellmanFordDirected() {
            var graph = new Graph<char>(GraphType.Directed);

            graph.AddEdge('s', 'a', 10);
            graph.AddEdge('s', 'e', 8);
            graph.AddEdge('e', 'd', 1);
            graph.AddEdge('a', 'c', 2);
            graph.AddEdge('d', 'a', -4);
            graph.AddEdge('d', 'c', -1);
            graph.AddEdge('c', 'b', -2);
            graph.AddEdge('b', 'a', 1);

            var result = BellmanFord<char>.FindShortestPaths(graph, 's');

            Assert.Equal(0, result['s']);
            Assert.Equal(5, result['a']);
            Assert.Equal(8, result['e']);
            Assert.Equal(9, result['d']);
            Assert.Equal(7, result['c']);
            Assert.Equal(5, result['b']);
        }
    }
}
