using System;
using System.Collections.Generic;

namespace EBAlgorithms {

    /// <summary>
    /// List extensions for Merge Sort.
    /// </summary>
    public static class MergeSortListExtensions {
        
        /// <summary>
        /// Sorts the current list using Merge Sort.
        /// </summary>
        public static void MergeSort<T>(this List<T> list) where T : IComparable {
            DivideAndConquer(list, 0, list.Count - 1);
        }

        private static void DivideAndConquer<T>(List<T> list, int leftIndex, int rightIndex) where T : IComparable {
            if (rightIndex > leftIndex) {
                int midIndex = (leftIndex + rightIndex) / 2;

                DivideAndConquer(list, leftIndex, midIndex);
                DivideAndConquer(list, midIndex + 1, rightIndex);

                Merge(list, leftIndex, midIndex + 1, rightIndex);
            }
        }

        private static void Merge<T>(List<T> list, int leftIndex, int midIndex, int rightIndex) where T : IComparable {
            var count = rightIndex - leftIndex + 1;
            var leftEndIndex = midIndex - 1;
            var sortedSubList = new List<T>(list);
            var sortedListPos = leftIndex;

            while (leftIndex <= leftEndIndex && midIndex <= rightIndex) {
                if (list[leftIndex].CompareTo(list[midIndex]) < 0) {
                    sortedSubList[sortedListPos++] = list[leftIndex++];
                } else {
                    sortedSubList[sortedListPos++] = list[midIndex++];
                }
            }

            while (leftIndex <= leftEndIndex) {
                sortedSubList[sortedListPos++] = list[leftIndex++];
            }

            while (midIndex <= rightIndex) {
                sortedSubList[sortedListPos++] = list[midIndex++];
            }

            for (int k = 0; k < count; k++) {
                list[rightIndex] = sortedSubList[rightIndex];
                rightIndex--;
            }
        }
    }
}
