using System;
using System.Collections.Generic;

namespace EBAlgorithms {
    public class CountingSort<T> {
        private List<T> list;

        public CountingSort(List<T> list) {
            this.list = list;
        }

        public void Sort() { 
            // Using a sorted dictionary might be cheating, but this saves space and handles the generic type.
            var countDict = new SortedDictionary<T, int>();

            foreach (var item in list) {
                if (countDict.ContainsKey(item)) {
                    countDict[item]++;
                } else {
                    countDict.Add(item, 1);
                }
            }

            var i = 0;
            foreach (var item in countDict) {
                for (var j = 0; j < item.Value; j++) {
                    list[i++] = item.Key;
                }
            }
        }
    }

    public class CountingSortInt {
        public static void Sort(List<int> list, int significantDigit) {
            var output = new int[list.Count];
            var counts = new int[10];

            for (var i = 0; i < list.Count; i++) {
                int digit = (list[i] / significantDigit) % 10;
                counts[digit]++;
            }

            for (var i = 1; i < 10; i++) {
                counts[i] += counts[i - 1];
            }

            for (var i = list.Count - 1; i >= 0; i--) {
                int digit = (list[i] / significantDigit) % 10;
                output[counts[digit] - 1] = list[i];
                counts[digit]--;
            }

            for (var i = 0; i < list.Count; i++) {
                list[i] = output[i];
            }
        }
    }
}
