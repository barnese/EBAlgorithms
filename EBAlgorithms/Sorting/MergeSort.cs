using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Original code: non-in-place sorting.

        //private static List<T> DivideAndConquer<T>(List<T> list) where T : IComparable {
        //    if (list.Count > 0) {
        //        int midPoint = list.Count / 2;

        //        var leftList = list.GetRange(0, midPoint);
        //        var rightList = list.GetRange(midPoint, midPoint);

        //        if (midPoint > 1) {
        //            leftList = DivideAndConquer(leftList);
        //            rightList = DivideAndConquer(rightList);
        //        }

        //        return Merge(leftList, rightList);
        //    }

        //    return new List<T>(0);
        //}

        //private static List<T> Merge<T>(List<T> leftList, List<T> rightList) where T : IComparable {
        //    int count = leftList.Count + rightList.Count;
        //    var sortedList = new List<T>(count);

        //    // Merge the two lists using "two finger" algorithm, i and j are the fingers.
        //    int i = 0;
        //    int j = 0;

        //    for (int k = 0; k < count; k++) {
        //        if (j >= rightList.Count && i < leftList.Count) {
        //            sortedList.Add(leftList[i]);
        //            i++;
        //        } else if (j < rightList.Count && i >= leftList.Count) {
        //            sortedList.Add(rightList[j]);
        //            j++;
        //        } else if (leftList[i].CompareTo(rightList[j]) < 0) { // leftList[i] < rightList[j]
        //            sortedList.Add(leftList[i]);
        //            i++;
        //        } else {
        //            sortedList.Add(rightList[j]);
        //            j++;
        //        }
        //    }

        //    return sortedList;
        //}
    }
}
