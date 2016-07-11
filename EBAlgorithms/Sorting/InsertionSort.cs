using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAlgorithms {

    /// <summary>
    /// List extensions for Insertion Sort.
    /// </summary>
    public static class InsertionSortListExtensions {

        /// <summary>
        /// Sorts the current list using Insertion Sort.
        /// </summary>
        public static void InsertionSort<T>(this List<T> list) where T : IComparable {
            for (int i = 1; i < list.Count; i++) {
                var key = list[i];
                var j = i - 1;

                while (j >= 0 && list[j].CompareTo(key) > 0) { // list[j] > key
                    list[j + 1] = list[j];
                    j = j - 1;
                }

                list[j + 1] = key;
            }
        }
    }
}
