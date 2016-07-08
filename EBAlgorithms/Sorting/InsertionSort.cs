using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAlgorithms {

    public class InsertionSort<T>: BaseSort<T> where T : IComparable {

        /// <summary>
        /// Sorts a given list using insertion sort.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <returns>Sorted list.</returns>
        public static List<T> Sort(List<T> list) {
            for (int i = 1; i < list.Count; i++) {
                var key = list[i];
                var j = i - 1;
                
                while (j >= 0 && list[j].CompareTo(key) > 0) { // list[j] > key
                    list[j + 1] = list[j];
                    j = j - 1;
                }

                list[j + 1] = key;                
            }

            return list;
        }
    }
}
