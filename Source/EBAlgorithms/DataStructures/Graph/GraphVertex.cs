using System;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {
    /// <summary>
    /// Defines a generic vertex in a graph.
    /// </summary>
    public class GraphVertex<T> where T : IComparable {
        public T value;
        public List<GraphEdge<T>> edges = new List<GraphEdge<T>>();
        public GraphVertexStatus status = GraphVertexStatus.Unvisited;
        public int discoveryTime = 0;
        public int finishTime = 0;
        public int level = 0;

        public GraphVertex() { }

        public GraphVertex(T value) {
            this.value = value;
        }

        public GraphVertex(T value, T neighbor, int weight) {
            this.value = value;
            edges.Add(new GraphEdge<T>(neighbor, weight));
        }

        public void AddEdge(T vertex, int weight) {
            if (!ContainsEdge(vertex)) {
                edges.Add(new GraphEdge<T>(vertex, weight));
                edges.Sort();
            }
        }

        public void Reset() {
            discoveryTime = 0;
            finishTime = 0;
            level = 0;
            status = GraphVertexStatus.Unvisited;
        }

        private bool ContainsEdge(T vertex) {
            foreach (var edge in edges) {
                if (edge.Vertex.CompareTo(vertex) == 0) {
                    return true;
                }
            }

            return false;
        }
    }
}
