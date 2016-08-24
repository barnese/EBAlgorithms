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
        /// Determines the shortest paths in the graph using Dijkstra's algorithm.
        /// </summary>
        public List<T> FindShortestPathsByDijkstra(T startVertex) {
            var shortestPaths = new List<T>();
            var uncheckedVertices = new List<T>();
            var distances = new Dictionary<T, int>();
            
            // Put all the vertices into the unchecked list and initialize all distances to "infinity".
            foreach (var v in vertices) {
                uncheckedVertices.Add(v.Key);
                distances.Add(v.Key, int.MaxValue);
            }

            // The start vertex's distance is zero, since we start from there.
            distances[startVertex] = 0;

            while (uncheckedVertices.Count > 0) {
                // Extract the minimum vertex based on its values in distances.
                var u = FindMinimumDistanceVertex(uncheckedVertices, distances);
                uncheckedVertices.Remove(u);

                // Add the minimum vertex to the shortest paths list.
                shortestPaths.Add(u);

                // Relax each neighboring vertex so that the distance always has the smallest value.
                foreach (var v in vertices[u].edges) {
                    if (distances[v.Vertex] > distances[u] + v.Weight) {
                        distances[v.Vertex] = distances[u] + v.Weight;
                    }
                }
            }

            return shortestPaths;
        }

        /// <summary>
        /// Given a list of vertices, determines which is the smallest based on a dictionary of distances.
        /// </summary>
        private T FindMinimumDistanceVertex(List<T> vertices, Dictionary<T, int> distances) {
            var minimumDistance = int.MaxValue;
            var minimumVertex = vertices[0];

            foreach (var vertex in vertices) {
                if (distances[vertex] < minimumDistance) {
                    minimumDistance = distances[vertex];
                    minimumVertex = vertex;
                }
            }

            return minimumVertex;
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
