using System;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {
    public enum GraphType {
        Directed,
        Undirected
    }

    /// <summary>
    /// This graph data structure uses a dictionary of vertices and an 
    /// "Adjacency List" (as a linked list) of their neighboring vertices.
    /// </summary>
    public class Graph<T> {
        private GraphType type;
        private Dictionary<T, LinkedList<T>> adjDict;

        public Graph(GraphType type = GraphType.Undirected) {
            adjDict = new Dictionary<T, LinkedList<T>>();
            this.type = type;
        }

        public void AddEdge(T firstVertex, T secondVertex) {
            _AddEdge(firstVertex, secondVertex);

            if (type == GraphType.Undirected) {
                _AddEdge(secondVertex, firstVertex);
            }
        }

        private void _AddEdge(T firstVertex, T secondVertex) {
            LinkedList<T> linkedList;

            if (!adjDict.ContainsKey(firstVertex)) {
                linkedList = new LinkedList<T>();
                linkedList.Add(secondVertex);
                adjDict.Add(firstVertex, linkedList);
            } else {
                linkedList = adjDict[firstVertex];

                if (!linkedList.Contains(secondVertex)) {
                    linkedList.Add(secondVertex);
                }
            }
        }

        /// <summary>
        /// Traverses the graph using breadth-first search from the given vertex. 
        /// A callback is invoked on each vertex visit.
        /// </summary>
        public void BreadthFirstSearch(T startVertex, Action<T> callback) {
            var level = new Dictionary<T, int>() { { startVertex, 0 } };
            var parent = new Dictionary<T, T>() { { startVertex, default(T) } };

            var frontier = new LinkedList<T>() { startVertex };
            callback(startVertex);

            var i = 1;

            while (frontier.Count > 0) {
                var next = new LinkedList<T>();

                foreach (var vertex in frontier) {
                    if (adjDict.ContainsKey(vertex)) {
                        foreach (var neighbor in adjDict[vertex]) {
                            if (!level.ContainsKey(neighbor)) {
                                level[neighbor] = i;
                                parent[neighbor] = vertex;
                                next.Add(neighbor);
                                callback(neighbor);
                            }
                        }
                    }
                }

                frontier = next;
                i++;
            }
        }

        /// <summary>
        /// Traverses all vertices in the graph using depth-first search.
        /// A callback is invoked on each vertex visit.
        /// </summary>
        public void DepthFirstSearch(Action<T> callback) {
            var visited = new List<T>();

            foreach (var vertex in adjDict.Keys) {
                if (!visited.Contains(vertex)) {
                    DepthFirstSearchVisit(vertex, visited, callback);
                }
            }
        }

        private void DepthFirstSearchVisit(T startVertex, List<T> visited, Action<T> callback) {
            visited.Add(startVertex);
            callback(startVertex);

            if (adjDict.ContainsKey(startVertex)) {
                foreach (var vertex in adjDict[startVertex]) {
                    if (!visited.Contains(vertex)) {                        
                        DepthFirstSearchVisit(vertex, visited, callback);
                    }
                }
            }
        }

        public void Describe() {
            Console.WriteLine("Graph is {0}", type.ToString());

            foreach (var vertex in adjDict) {
                Console.Write("{0}: ", vertex.Key);

                foreach (var item in vertex.Value) {
                    Console.Write("{0} ", item);
                }

                Console.WriteLine();
            }
        }

        public void RemoveEdge(T firstVertex, T secondVertex) {
            _RemoveEdge(firstVertex, secondVertex);

            if (type == GraphType.Undirected) {
                _RemoveEdge(secondVertex, firstVertex);
            }
        }

        private void _RemoveEdge(T firstVertex, T secondVertex) {
            if (adjDict.ContainsKey(firstVertex)) {

                var linkedList = adjDict[firstVertex];
                linkedList.Delete(secondVertex);

                if (linkedList.Count == 0) {
                    adjDict.Remove(firstVertex);
                }
            }
        }
    }
}
