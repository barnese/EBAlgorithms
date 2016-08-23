using System;
using System.Collections.Generic;

namespace EBAlgorithms.DataStructures {
    public enum HeapType {
        MinHeap = 1,
        MaxHeap = -1
    }

    /// <summary>
    /// Generic implementation of a heap.
    /// MinHeap (default) and MaxHeap types implemented.
    /// </summary>
    public class Heap<T> where T : IComparable {
        private List<T> list = new List<T>();
        private HeapType type;

        public Heap(List<T> list, HeapType type = HeapType.MinHeap) {
            this.list = list;
            this.type = type;
            BuildHeap();
        }

        public Heap(HeapType type = HeapType.MinHeap) {
            this.type = type;
        }

        public int Count {
            get { return list.Count; }
        }

        public List<T> ToList() {
            return list;
        }

        #region Heap Position Helpers
        private int Parent(int index) {
            return (index - 1) / 2;
        }

        private int LastParent() {
            return list.Count / 2 - 1;
        }

        private bool IsLeaf(int index) {
            return index > (list.Count / 2 - 1) && index < list.Count;
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
            list.Add(item);

            // Trickle the item up in the tree until it restores the heap's proper ordering.
            TrickleUp(list.Count - 1);
        }

        private void BuildHeap() {
            // Start heapifying at the last parent node in the heap and work backwards.
            for (var i = LastParent(); i >= 0; i--) {
                Heapify(i, list.Count - 1);
            }
        }

        public string Describe() {
            if (list.Count == 0) {
                return "Empty";
            }

            var description = "";

            foreach (T item in list) {
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
                if (child + 1 <= end && list[child + 1].CompareTo(list[child]) * (int)type < 0) {
                    child++;
                }

                // For MinHeap: Is the largest child greater than the root? For MaxHeap: Vice versa.
                if (list[child].CompareTo(list[root]) * (int)type < 0) {
                    Swap(root, child);
                    root = child;
                } else {
                    break;
                }
            }
        }

        public T RemoveRoot() {
            if (list.Count == 0) {
                throw new Exception("The heap is empty!");
            }

            var item = list[0];

            list[0] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            Heapify(0, list.Count - 1);

            return item;
        }

        public void Sort() {
            BuildHeap();

            int i = list.Count - 1;

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
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        private void TrickleUp(int index) {
            if (index == 0)
                return;

            var parentIndex = Parent(index);

            if (list[parentIndex].CompareTo(list[index]) * (int)type > 0) {
                Swap(parentIndex, index);
                TrickleUp(parentIndex);
            }
        }
    }
}
