using System;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {
    public enum HeapType {
        MinHeap = -1,
        MaxHeap = 1
    }

    public class Heap<T> where T : IComparable {
        private List<T> heap = new List<T>();
        private HeapType type;

        public Heap(List<T> heap, HeapType type = HeapType.MinHeap) {
            this.heap = heap;
            this.type = type;
            BuildHeap();
        }

        public Heap(HeapType type = HeapType.MinHeap) {
            this.type = type;
        }

        #region Heap Position Helpers
        private int Parent(int index) {
            return index / 2;
        }

        private int LastParent() {
            return heap.Count / 2 - 1;
        }

        private bool IsLeaf(int index) {
            return index > (heap.Count / 2 - 1) && index < heap.Count;
        }
        
        private int Left(int index) {
            return 2 * index + 1;
        } 

        private int Right(int index) {
            return 2 * index + 2;
        }
        #endregion

        public void Add(T item) {
            // Add the new item to the end of the heap.
            heap.Add(item);
            BuildHeap();
        }

        private void BuildHeap() {
            // Start heapifying at the last parent node in the heap and work backwards.
            for (var i = LastParent(); i >= 0; i--) {
                Heapify(i);
            }
        }

        public string Describe() {
            var description = "";

            foreach (T item in heap) {
                description += item + " ";
            }

            return description.TrimEnd();
        }

        private void Heapify(int root) {
            if (IsLeaf(root))
                return;
           
            var leftIndex = Left(root);
            var rightIndex = Right(root);

            // Find the smaller/larger child. Start with the left child.
            var child = Left(root);

            // For MinHeap: If the right child is greater than the left child, use it. MaxHeap: Vice versa.
            if (rightIndex < heap.Count && heap[rightIndex].CompareTo(heap[leftIndex]) * (int)type > 0) {
                child++;
            }

            if (heap[root].CompareTo(heap[child]) * (int)type < 0) {
                Swap(root, child);
                Heapify(child);
            }
        }

        private void Swap(int i, int j) {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
