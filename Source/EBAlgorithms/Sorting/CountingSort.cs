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
        private List<int> list;
        private int maxNumberOfValues = 256;

        public CountingSortInt(List<int> list, int maxNumberOfValues) {
            this.list = list;
            this.maxNumberOfValues = maxNumberOfValues;
        }

        public void Sort() {
            var countingArray = new int[maxNumberOfValues];

            for (var i = 0; i < list.Count; i++) {
                if (list[i] >= maxNumberOfValues) {
                    throw new Exception("A value in the list exceeded the maximum allowed values. Increase maxNumberOfValues.");
                }

                countingArray[list[i]] = countingArray[list[i]] + 1;
            }

            var index = 0;
            for (var i = 0; i < countingArray.Length; i++) {
                if (countingArray[i] > 0) {
                    for (var j = 0; j < countingArray[i]; j++) {
                        list[index++] = i;
                    }
                }
            }
        }
    }
}
