using System;
using System.Collections.Generic;

namespace EBAlgorithms {
    public class QuickSort<T> where T : IComparable {
        private List<T> list;

        public QuickSort(List<T> list) {
            this.list = list;
        }

        public void Sort() {
            Sort(0, list.Count - 1);
        }

        private void Sort(int p, int r) {
            if (p < r) {
                var q = Partition(p, r);
                Sort(p, q - 1);
                Sort(q + 1, r);
            }
        }

        /// <summary>
        /// Partitions the subarray such that elements less than the pivot are on the left
        /// and all others are on the right. The pivot is chosen to be list[r].
        /// </summary>
        /// <returns>Index of the pivot</returns>
        private int Partition(int p, int r) {
            var q = p;

            for (var j = p; j < r; j++) {
                if (list[j].CompareTo(list[r]) <= 0) {
                    Swap(j, q++);
                }
            }

            Swap(r, q);

            return q;
        }

        private void Swap(int i, int j) {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
