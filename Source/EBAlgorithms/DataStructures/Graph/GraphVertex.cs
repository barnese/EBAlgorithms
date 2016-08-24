using System;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {
    /// <summary>
    /// Defines a generic vertex in a graph.
    /// </summary>
    public class GraphVertex<T> where T : IComparable {
        public T Value;
        public GraphVertexStatus Status = GraphVertexStatus.Unvisited;
        public int DiscoveryTime = 0;
        public int FinishTime = 0;
        public int Level = 0;

        public GraphVertex() { }

        public GraphVertex(T value) {
            this.Value = value;
        }

        public void Reset() {
            DiscoveryTime = 0;
            FinishTime = 0;
            Level = 0;
            Status = GraphVertexStatus.Unvisited;
        }

        public override string ToString() {
            return Value.ToString();
        }
    }
}
