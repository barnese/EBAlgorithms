using System;
using System.Collections.Generic;
using System.Linq;

namespace EBAlgorithms.DataStructures {
    public class BellmanFord<T> where T : IComparable {
        /// <summary>
        /// Determines the shortest paths in the graph using Bellman-Ford's algorithm.
        /// </summary>
        /// <returns>
        /// Dictionary containing vertices and the minimum cost (in total weights) from the
        /// starting vertex to each vertex. Throws an exception if a negative cycle is found
        /// in the graph.
        /// </returns>
        public static Dictionary<T, int> FindShortestPaths(Graph<T> graph, T startVertex) {
            var distances = new Dictionary<T, int>();

            // Put all the vertices into the unchecked list and initialize all distances to "infinity".
            foreach (var v in graph.Vertices) {
                distances.Add(v.Key, int.MaxValue);
            }

            // The start vertex's distance is zero, since we start from there.
            distances[startVertex] = 0;

            // Relax each neighboring vertex so that the distance always has the smallest value.
            for (var i = 0; i < graph.Vertices.Count - 1; i++) {
                foreach (var edge in graph.Edges) {
                    if (distances[edge.Vertex1] != int.MaxValue &&
                        distances[edge.Vertex2] > distances[edge.Vertex1] + edge.Weight) {
                        distances[edge.Vertex2] = distances[edge.Vertex1] + edge.Weight;
                    }
                }
            }

            // Make one more pass to ensure there are no negative cycles.
            foreach (var edge in graph.Edges) {
                if (distances[edge.Vertex2] > distances[edge.Vertex1] + edge.Weight) {
                    throw new Exception("Found a negative cycle!");
                }
            }

            return distances;
        }
    }
}
