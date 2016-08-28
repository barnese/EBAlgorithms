using System;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {
    public class Dijkstra<T> where T : IComparable {
        /// <summary>
        /// Determines the shortest paths in the graph using Dijkstra's algorithm.
        /// </summary>
        public static Dictionary<T, int> FindShortestPaths(Graph<T> graph, T startVertex, T endVertex = default(T)) {
            var uncheckedVertices = new List<T>();
            var distances = new Dictionary<T, int>();

            // Put all the vertices into the unchecked list and initialize all distances to "infinity".
            foreach (var v in graph.Vertices) {
                uncheckedVertices.Add(v.Key);
                distances.Add(v.Key, int.MaxValue);
            }

            // The start vertex's distance is zero, since we start from there.
            distances[startVertex] = 0;

            while (uncheckedVertices.Count > 0) {
                // Extract the minimum vertex based on its values in distances.
                var u = FindMinimumDistanceVertex(uncheckedVertices, distances);
                uncheckedVertices.Remove(u);

                // If endVertex was provided, stop checking since we have reached that vertex.
                if (endVertex.CompareTo(u) == 0) {
                    var result = new Dictionary<T, int>();
                    result.Add(u, distances[u]);
                    return result;
                }

                // Relax each neighboring vertex so that the distance always has the smallest value.                
                foreach (var v in graph.FindEdgesForVertex(u)) {
                    if (distances[v.Vertex2] > distances[u] + v.Weight) {
                        distances[v.Vertex2] = distances[u] + v.Weight;
                    }
                }                
            }

            return distances;
        }

        /// <summary>
        /// Given a list of vertices, determines which is the smallest based on a dictionary of distances.
        /// </summary>
        private static T FindMinimumDistanceVertex(List<T> vertices, Dictionary<T, int> distances) {
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
    }
}
