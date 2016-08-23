using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBAlgorithms.DataStructures {
    public class GraphEdge<T> : IComparable where T : IComparable {
        private T vertex;
        private int weight;

        public T Vertex { get { return vertex; } }
        public int Weight { get { return weight; } }

        public GraphEdge(T vertex) {
            this.vertex = vertex;
            this.weight = -1;
        }

        public GraphEdge(T vertex, int weight) {
            this.vertex = vertex;
            this.weight = weight;
        }

        public int CompareTo(object obj) {
            if (obj == null) return 1;

            GraphEdge<T> other = obj as GraphEdge<T>;
            if (other != null)
                return this.Vertex.CompareTo(other.Vertex);
            else
                throw new ArgumentException("Object is not a Temperature");
        }
    }
}
