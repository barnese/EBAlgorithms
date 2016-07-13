using System;
using System.Collections.Generic;

namespace EBAlgorithms {

    /// <summary>
    /// List extensions for Merge Sort.
    /// </summary>
    public static class HeapSortListExtensions {

        /// <summary>
        /// Sorts the current list using Heap Sort.
        /// 
        /// Basic algorithm:
        /// 1. Build a heap.
        /// 2. Transform the heap into a min heap (if sorting in ascending order otherwise max heap).
        /// 3. Delete the root node.
        /// 4. Put the last node of the heap in the root position.
        /// 5. Repeat from step 2 until all nodes are covered.
        /// 
        /// </summary>
        public static void HeapSort<T>(this List<T> list) where T : IComparable {
            
        }

        private static void buildMinHeap<T>(List<T> list) where T : IComparable {
            for (int i = list.Count / 2; i >= 0; i--) {
                minHeapify(list, i);
            }
        }

        private static void buildMaxHeap<T>(List<T> list) where T : IComparable {
            for (int i = list.Count / 2; i >= 0; i--) {
                maxHeapify(list, i);
            }
        }

        private static void minHeapify<T>(List<T> list, int index) where T : IComparable {
            // Is any child node less than list[index]?
            // TODO
        }

        private static void maxHeapify<T>(List<T> list, int index) where T : IComparable {

        }

        private static void swap<T>(List<T> list, int leftIndex, int rightIndex) where T : IComparable {
            T temp = list[rightIndex];
            list[leftIndex] = list[rightIndex];
            list[rightIndex] = temp;
        }
    }
}
