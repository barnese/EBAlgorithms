using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBAlgorithms.DataStructures {
    public class GraphEdge<T> : IComparable where T : IComparable {
        private T vertex1;
        private T vertex2;
        private int weight;

        public T Vertex1 { get { return vertex1; } }
        public T Vertex2 { get { return vertex2; } }
        public int Weight { get { return weight; } }

        public GraphEdge(T vertex1, T vertex2) {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.weight = -1;
        }

        public GraphEdge(T vertex1, T vertex2, int weight) {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.weight = weight;
        }

        public int CompareTo(object obj) {
            if (obj == null) return 1;

            GraphEdge<T> other = obj as GraphEdge<T>;

            if (other == null)
                throw new ArgumentException("Object is not a GraphEdge");

            return this.Vertex1.CompareTo(other.Vertex1) + this.Vertex2.CompareTo(other.Vertex2);
        }
    }
}
