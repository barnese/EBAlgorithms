using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBAlgorithms {
    public class HeapsAlgorithm {
        /// <summary>
        /// Returns all permutations of a list of integers.
        /// </summary>
        public static List<List<int>> FindPermutations(List<int> list) {
            var perms = new List<List<int>>();                      
            FindPermutations(list, list.Count, perms);
            return perms;
        }

        private static void FindPermutations(List<int> list, int size, List<List<int>> perms) {
            if (size == 1) {
                perms.Add(new List<int>(list));
                return;
            }

            for (var i = 0; i < size; i++) {
                FindPermutations(list, size - 1, perms);

                if (size % 2 == 0) {
                    list.Swap(i, size - 1);
                } else {
                    list.Swap(0, size - 1);
                }
            }
        }
    }
}
