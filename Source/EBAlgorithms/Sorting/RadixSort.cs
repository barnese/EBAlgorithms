using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBAlgorithms {
    public class RadixSortInt {
        public static void Sort(List<int> list) {
            var max = getMaxValue(list);

            // Iterate through each significant digit and sort the list.
            for (var i = 1; max / i > 0; i *= 10) {
                CountingSortInt.Sort(list, i);
            }
        }

        private static int getMaxValue(List<int> list) {
            if (list.Count == 0) {
                return 0;
            }

            int max = list[0];
            foreach (var item in list) {
                if (item > max) {
                    max = item;
                }
            }

            return max;
        }
    }
}
