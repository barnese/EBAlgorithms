using System;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {
    /// <summary>
    /// Defines a generic vertex in a graph.
    /// </summary>
    public class GraphVertex<T> {
        public T value;
        public List<T> neighbors = new List<T>();
        public GraphVertexStatus status = GraphVertexStatus.Unvisited;
        public int discoveryTime = 0;
        public int finishTime = 0;
        public int level = 0;

        public GraphVertex() { }

        public GraphVertex(T value) {
            this.value = value;
        }

        public GraphVertex(T value, T neighbor) {
            this.value = value;
            neighbors.Add(neighbor);
        }

        public void AddNeighbor(T vertex) {
            if (!neighbors.Contains(vertex)) {
                neighbors.Add(vertex);
                neighbors.Sort();
            }
        }

        public void Reset() {
            discoveryTime = 0;
            finishTime = 0;
            level = 0;
            status = GraphVertexStatus.Unvisited;
        }
    }
}
