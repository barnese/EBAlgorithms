using System;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {
    public enum HeapType {
        MinHeap = -1,
        MaxHeap = 1
    }

    /// <summary>
    /// Generic implementation of a heap.
    /// MinHeap (default) and MaxHeap types implemented.
    /// </summary>
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

        public List<T> ToList() {
            return heap;
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
            return Left(index) + 1;
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
                Heapify(i, heap.Count - 1);
            }
        }

        public string Describe() {
            var description = "";

            foreach (T item in heap) {
                description += item + " ";
            }

            return description.TrimEnd();
        }

        private void Heapify(int start, int end) {
            var root = start;

            while (root * 2 + 1 <= end) {
                // Start with the left child.
                var child = Left(root);

                // For MinHeap: If the right child is greater than the left child, use it. MaxHeap: Vice versa.
                if (child + 1 <= end && heap[child + 1].CompareTo(heap[child]) * (int)type > 0) {
                    child++;
                }

                // For MinHeap: Is the largest child greater than the root? For MaxHeap: Vice versa.
                if (heap[child].CompareTo(heap[root]) * (int)type > 0) {
                    Swap(root, child);
                    root = child;
                } else {
                    break;
                }
            }
        }

        public void Sort() {
            BuildHeap();

            int i = heap.Count - 1;

            while (i > 0) {
                // Swap the root with the last item in the heap.
                Swap(i, 0);

                // "Remove" the last item from consideration.
                i--;

                // Put the heap back into the proper order.
                Heapify(0, i);
            }
        }

        private void Swap(int i, int j) {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
