using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBAlgorithms {
    public static class ListExtensions {
        /// <summary>
        /// Swaps elements at the ith and jth indices in the list.
        /// </summary>
        public static void Swap<T>(this List<T> list, int i, int j) where T : IComparable {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
