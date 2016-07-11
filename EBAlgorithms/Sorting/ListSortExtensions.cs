using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAlgorithms {

    public static class ListSortExtensions {

        /// <summary>
        /// Determines if the list is sorted.
        /// </summary>
        public static bool IsSorted<T>(this List<T> list) where T : IComparable {
            for (int i = 1; i < list.Count; i++) {
                // list[i - 1] > list[i]
                if (list[i - 1].CompareTo(list[i]) > 0) {
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
