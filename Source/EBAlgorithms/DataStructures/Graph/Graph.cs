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
        private List<GraphEdge<T>> edges = new List<GraphEdge<T>>();

        private int dfsTime = 0;

        public Graph(GraphType type = GraphType.Undirected) {
            this.type = type;
        }

        public List<GraphEdge<T>> Edges { get { return edges; } }
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
        public void AddEdge(T vertex1, T vertex2, int weight = -1) {
            AddVertex(vertex1);
            AddVertex(vertex2);

            _AddEdge(vertex1, vertex2, weight);

            if (type == GraphType.Undirected) {
                _AddEdge(vertex2, vertex1, weight);
            }
        }

        private void _AddEdge(T vertex1, T vertex2, int weight) {
            if (!ContainsEdge(vertex1, vertex2)) {
                edges.Add(new GraphEdge<T>(vertex1, vertex2, weight));
                edges.Sort();
            }
        }

        /// <summary>
        /// Determines if the given edge exists in the graph.
        /// </summary>
        public bool ContainsEdge(T vertex1, T vertex2) {
            foreach (var edge in edges) {
                if (edge.Vertex1.CompareTo(vertex1) == 0 && edge.Vertex2.CompareTo(vertex2) == 0) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Prints a graph description to the console.
        /// </summary>
        public void Describe() {
            Console.WriteLine("Graph is {0}", type.ToString());

            foreach (var vertex in vertices) {
                foreach (var edge in edges) {
                    if (edge.Vertex1.CompareTo(vertex.Value.Value) == 0) {
                        Console.WriteLine("{0} -> {1} {2} ", vertex.Value, edge.Vertex2, edge.Weight);
                    }
                }
            }
        }

        /// <summary>
        /// Finds all edges for the given vertex.
        /// </summary>
        public List<GraphEdge<T>> FindEdgesForVertex(T vertex) {
            return edges.FindAll(e => e.Vertex1.CompareTo(vertex) == 0);
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

            vertices[vertex].Level = 0;
            vertices[vertex].Status = GraphVertexStatus.Discovered;
            result.Add(vertex);

            foreach (var edge in FindEdgesForVertex(vertex)) {
                vertices[edge.Vertex2].Level = vertices[vertex].Level + 1;
                queue.Enqueue(edge.Vertex2);
            }

            while (!queue.IsEmpty()) {
                var v = queue.Dequeue();

                if (vertices[v].Status == GraphVertexStatus.Unvisited) {
                    vertices[v].Status = GraphVertexStatus.Discovered;
                    result.Add(vertices[v].Value);

                    foreach (var edge in FindEdgesForVertex(vertices[v].Value)) {
                        if (vertices[edge.Vertex2].Status == GraphVertexStatus.Unvisited) {
                            queue.Enqueue(edge.Vertex2);

                            if (vertices[edge.Vertex2].Level > vertices[v].Level + 1) {
                                vertices[edge.Vertex2].Level = vertices[v].Level + 1;
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
                if (v.Value.Status == GraphVertexStatus.Unvisited) {
                    DepthFirstSearchVisit(v.Key, result);
                }
            }

            return result;
        }

        private void DepthFirstSearchVisit(T startVertex, List<T> result) {
            var vertex = vertices[startVertex];
            vertex.Status = GraphVertexStatus.Discovered;
            vertex.DiscoveryTime = dfsTime++;
            result.Add(vertex.Value);

            foreach (var edge in FindEdgesForVertex(startVertex)) {
                if (vertices.ContainsKey(edge.Vertex2) && vertices[edge.Vertex2].Status == GraphVertexStatus.Unvisited) {
                    DepthFirstSearchVisit(edge.Vertex2, result);
                }
            }

            vertex.Status = GraphVertexStatus.Finished;
            vertex.FinishTime = dfsTime++;
        }

        /// <summary>
        /// Returns a list of topologically sorted vertices.
        /// </summary>
        public List<T> TopologicalSort(T vertex) {
            DepthFirstSearch(vertex);

            // Sort the vertices by finish time.
            var sortedDict = new SortedDictionary<int, T>();

            foreach (var v in vertices) {
                sortedDict.Add(v.Value.FinishTime, v.Key);
            }

            // Return the vertices in reverse order.
            return sortedDict.Values.Reverse().ToList();
        }
    }
}
