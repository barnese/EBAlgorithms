using System;
using System.Collections.Generic;

namespace EBAlgorithms {

    public enum HeapSortType {
        MaxHeap = -1,
        MinHeap = 1
    }

    public class HeapSort<T> where T : IComparable {

        private List<T> list;
        private HeapSortType type;

        public HeapSort(List<T> list) {
            this.list = list;
        }

        public void Sort(HeapSortType type = HeapSortType.MinHeap) {
            this.type = type;

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

        private void BuildHeap() {
            // Start heapifying at the last parent node in the heap and work backwards.
            for (int i = list.Count / 2 - 1; i >= 0; i--) {
                Heapify(i, list.Count - 1);
            }
        }

        private void Heapify(int start, int end) {
            var root = start;

            while (root * 2 + 1 <= end) {
                // Start with the left child.
                var child = root * 2 + 1;

                // For MinHeap: If the right child is greater than the left child, use it. MaxHeap: Vice versa.
                if (child + 1 <= end && list[child + 1].CompareTo(list[child]) * (int)type > 0) {
                    child++;
                }

                // For MinHeap: Is the largest child greater than the root? For MaxHeap: Vice versa.
                if (list[child].CompareTo(list[root]) * (int)type > 0) {
                    Swap(root, child);
                    root = child;
                } else {
                    break;
                }
            }
        }

        private void Swap(int i, int j) {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
