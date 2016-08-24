using System;
using System.Collections.Generic;
using System.Linq;

namespace EBAlgorithms.DataStructures {
    /// <summary>
    /// Defines a generic graph.
    /// </summary>
    public class Graph<T> where T : IComparable {
        private GraphType type;
        private Dictionary<T, GraphVertex<T>> vertices = new Dictionary<T, GraphVertex<T>>();
        private int dfsTime = 0;

        public Graph(GraphType type = GraphType.Undirected) {
            this.type = type;
        }

        public Dictionary<T, GraphVertex<T>> Vertices { get { return vertices; } }

        /// <summary>
        /// Adds a vertex to the graph.
        /// </summary>
        public void AddVertex(T vertex) {
            if (!vertices.ContainsKey(vertex)) {
                vertices.Add(vertex, new GraphVertex<T>(vertex));
            }
        }

        /// <summary>
        /// Adds an edge to the graph. Automatically adds new vertices.
        /// </summary>
        public void AddEdge(T firstVertex, T secondVertex, int weight = -1) {
            _AddEdge(firstVertex, secondVertex, weight);

            if (type == GraphType.Undirected) {
                _AddEdge(secondVertex, firstVertex, weight);
            }
        }

        private void _AddEdge(T firstVertex, T secondVertex, int weight) {
            if (!vertices.ContainsKey(firstVertex)) {
                var vertex = new GraphVertex<T>(firstVertex, secondVertex, weight);
                vertices.Add(firstVertex, vertex);
            } else {
                vertices[firstVertex].AddEdge(secondVertex, weight);
            }
        }

        /// <summary>
        /// Prints a graph description to the console.
        /// </summary>
        public void Describe() {
            Console.WriteLine("Graph is {0}", type.ToString());

            foreach (var vertex in vertices) {
                foreach (var item in vertex.Value.edges) {
                    Console.WriteLine("{0} -> {1} {2} ", vertex.Key, item.Vertex, item.Weight);
                }
            }
        }

        /// <summary>
        /// Searches the graph using breadth-first search.
        /// </summary>
        /// <returns>List of vertices from the search</returns>
        public List<T> BreadthFirstSearch(T vertex) {
            var result = new List<T>();
            var queue = new Queue<T>();

            // Reset all meta data so multiple searches will produce correct data.
            foreach (var v in vertices) {
                v.Value.Reset();
            }

            vertices[vertex].level = 0;
            vertices[vertex].status = GraphVertexStatus.Discovered;
            result.Add(vertex);

            foreach (var edge in vertices[vertex].edges) {
                var neighbor = edge.Vertex;
                vertices[neighbor].level = vertices[vertex].level + 1;
                queue.Enqueue(neighbor);
            }

            while (!queue.IsEmpty()) {
                var v = queue.Dequeue();

                if (vertices[v].status == GraphVertexStatus.Unvisited) {
                    vertices[v].status = GraphVertexStatus.Discovered;
                    result.Add(v);

                    foreach (var edge in vertices[v].edges) {
                        var neighbor = edge.Vertex;
                        if (vertices[neighbor].status == GraphVertexStatus.Unvisited) {
                            queue.Enqueue(neighbor);

                            if (vertices[neighbor].level > vertices[v].level + 1) {
                                vertices[neighbor].level = vertices[v].level + 1;
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Searches the graph using depth-first search.
        /// </summary>
        /// <returns>List of vertices from the search</returns>
        public List<T> DepthFirstSearch(T vertex) {
            dfsTime = 1;

            // Reset all meta data so multiple searches will produce correct data.
            foreach (var v in vertices) {
                v.Value.Reset();
            }

            var result = new List<T>();

            foreach (var v in vertices) {
                if (v.Value.status == GraphVertexStatus.Unvisited) {
                    DepthFirstSearchVisit(v.Key, result);
                }
            }

            return result;
        }

        private void DepthFirstSearchVisit(T startVertex, List<T> result) {
            var vertex = vertices[startVertex];
            vertex.status = GraphVertexStatus.Discovered;
            vertex.discoveryTime = dfsTime++;
            result.Add(vertex.value);

            foreach (var edge in vertex.edges) {
                var neighbor = edge.Vertex;
                if (vertices.ContainsKey(neighbor) && vertices[neighbor].status == GraphVertexStatus.Unvisited) {
                    DepthFirstSearchVisit(neighbor, result);
                }
            }

            vertex.status = GraphVertexStatus.Finished;
            vertex.finishTime = dfsTime++;
        }

        /// <summary>
        /// Returns a list of topologically sorted vertices.
        /// </summary>
        public List<T> TopologicalSort(T vertex) {
            DepthFirstSearch(vertex);

            // Sort the vertices by finish time.
            var sortedDict = new SortedDictionary<int, T>();

            foreach (var v in vertices) {
                sortedDict.Add(v.Value.finishTime, v.Key);
            }

            // Return the vertices in reverse order.
            return sortedDict.Values.Reverse().ToList();
        }
    }
}
