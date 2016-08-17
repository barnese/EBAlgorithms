using Xunit;
using EBAlgorithms.DataStructures;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class GraphTests {
        private Graph<int> graph;

        public GraphTests() {
            graph = new Graph<int>();

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 6);
            graph.AddEdge(4, 5);
        }

        [Fact]
        public void GraphTests_BreadthFirstSearchTest() {
            var expected = new List<int> { 0, 1, 2, 4, 3, 5, 6 };
            var result = new List<int>();

            graph.BreadthFirstSearch(0, (vertex) => {
                result.Add(vertex);
            });

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GraphTests_DepthFirstSearchTest() {
            var expected = new List<int> { 0, 1, 3, 5, 4, 2, 6 };
            var result = new List<int>();

            graph.DepthFirstSearch((vertex) => {
                result.Add(vertex);
            });

            Assert.Equal(expected, result);
        }
    }
}
