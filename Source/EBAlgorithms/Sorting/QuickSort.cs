using System;
using System.Collections.Generic;

namespace EBAlgorithms {
    public class QuickSort<T> where T : IComparable {
        private List<T> list;

        public QuickSort(List<T> list) {
            this.list = list;
        }

        /// <summary>
        /// Quicksort recursively partitions the array until it is sorted.
        /// Runtime complexity: O(n^2), but average case is O(n log n).
        /// </summary>
        public void Sort() {
            Sort(0, list.Count - 1);
        }

        private void Sort(int left, int right) {
            int index = Partition(left, right);

            if (left < index - 1) {
                Sort(left, index - 1);
            }

            if (index < right) {
                Sort(index, right);
            }
        }

        /// <summary>
        /// Partitions the subarray such that elements less than the pivot are on the left
        /// and all others are on the right. The pivot is chosen to be the subarray midpoint.
        /// </summary>
        /// <returns>Index of the pivot</returns>
        private int Partition(int left, int right) {
            T pivot = list[(left + right) / 2];

            while (left <= right) {
                while (list[left].CompareTo(pivot) < 0) { left++; }
                while (list[right].CompareTo(pivot) > 0) { right--; }

                if (left <= right) {
                    Swap(left++, right--);
                }
            }

            return left;
        }

        private void Swap(int i, int j) {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
