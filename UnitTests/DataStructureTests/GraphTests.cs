﻿using Xunit;
using EBAlgorithms.DataStructures;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class GraphTests {
        [Fact]
        public void GraphTests_UndirectedDFSTest() {
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
        public void GraphTests_DirectedDFSTest() {
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
            graph.AddVertex('f');
            graph.AddVertex('h');

            var result = "";

            foreach (var v in graph.DepthFirstSearch('a')) {
                result += v.ToString();
            }

            Assert.Equal("ghabcfdei", result);
        }

        [Fact]
        public void GraphTests_DirectedBFSTest() {
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

            var result = "";

            foreach (var v in graph.BreadthFirstSearch('a')) {
                result += v.ToString();
            }

            Assert.Equal("abdec", result);
        }

        [Fact]
        public void GraphTests_UndirectedBFSTest() {
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
    }
}
