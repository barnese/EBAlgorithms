using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAlgorithms {

    public class BaseSort<T> where T : IComparable {

        /// <summary>
        /// Determines if the list is sorted.
        /// </summary>
        /// <param name="list">The list to check</param>
        /// <returns>True if sorted, false otherwise.</returns>
        public static bool IsSorted(List<T> list) {
            for (int i = 1; i < list.Count; i++) {
                // list[i - 1] > list[i]
                if (list[i - 1].CompareTo(list[i]) > 0) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Swaps the elements in the given list at the given indices.
        /// </summary>
        protected static void Swap(List<T> list, int firstIndex, int secondIndex) {
            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
