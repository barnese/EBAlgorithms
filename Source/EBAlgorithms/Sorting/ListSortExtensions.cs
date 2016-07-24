using System;
using System.Collections.Generic;

namespace EBAlgorithms {

    public static class ListSortExtensions {

        /// <summary>
        /// Sorts the current list using AVL Sort. Note: only use when list contains unique values!
        /// </summary>
        public static void AVLSort<T>(this List<T> list) where T : IComparable {
            var avlSort = new AVLSort<T>(list);
            avlSort.Sort();
        }

        /// <summary>
        /// Sorts the current list using Counting Sort.
        /// </summary>
        public static void CountingSort<T>(this List<T> list) {
            var countingSort = new CountingSort<T>(list);
            countingSort.Sort();
        }

        /// <summary>
        /// Sorts the current list using Heap Sort.
        /// </summary>
        public static void HeapSort<T>(this List<T> list, SortDirection sortDirection = SortDirection.Ascending) where T : IComparable {
            var heapSort = new HeapSort<T>(list);
            heapSort.Sort(sortDirection);
        }

        /// <summary>
        /// Sorts the current list using Merge Sort.
        /// </summary>
        public static void MergeSort<T>(this List<T> list) where T : IComparable {
            var mergeSort = new MergeSort<T>(list);
            mergeSort.Sort();
        }

        /// <summary>
        /// Sorts the current list using Quick Sort.
        /// </summary>
        public static void QuickSort<T>(this List<T> list) where T : IComparable {
            var quickSort = new QuickSort<T>(list);
            quickSort.Sort();
        }

        /// <summary>
        /// Determines if the list is sorted.
        /// </summary>
        public static bool IsSorted<T>(this List<T> list, SortDirection direction = SortDirection.Ascending) where T : IComparable {
            for (int i = 1; i < list.Count; i++) {

                if (list[i - 1].CompareTo(list[i]) * (int)direction > 0) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Prints the current list to the console.
        /// </summary>
        public static void Print<T>(this List<T> list) where T : IComparable {
            var joinedList = String.Join(", ", list);
            Console.WriteLine(joinedList);
        }

        /// <summary>
        /// Prints whether or not the current list is sorted.
        /// </summary>
        public static void PrintIsSorted<T>(this List<T> list) where T : IComparable {
            if (list.IsSorted()) {
                Console.WriteLine("The list is sorted.");
            } else {
                Console.WriteLine("The list is not sorted.");
            }
        }
    }
}
