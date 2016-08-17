using Xunit;
using EBAlgorithms.DataStructures;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class GraphTests {
        private Graph<char> graph;

        public GraphTests() {
            graph = new Graph<char>();

            graph.AddEdge('a', 'b');
            graph.AddEdge('a', 'd');
            graph.AddEdge('a', 'e');
            graph.AddEdge('b', 'd');
            graph.AddEdge('b', 'c');
            graph.AddEdge('d', 'a');
            graph.AddEdge('d', 'e');
            graph.AddEdge('d', 'c');
        }

        [Fact]
        public void GraphTests_BreadthFirstSearchTest() {
            var expected = new List<char> { 'a', 'b', 'd', 'e', 'c' };
            var result = new List<char>();

            graph.BreadthFirstSearch('a', (vertex) => {
                result.Add(vertex);
            });

            Assert.Equal(expected, result);
        }
    }
}
