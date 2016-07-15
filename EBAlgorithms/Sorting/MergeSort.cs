using System;
using System.Collections.Generic;

namespace EBAlgorithms {

    public class MergeSort<T> where T : IComparable {
        private List<T> list;

        public MergeSort(List<T> list) {
            this.list = list;
        }

        public void Sort() {
            DivideAndConquer(0, list.Count - 1);
        }

        private void DivideAndConquer(int leftIndex, int rightIndex) {
            if (rightIndex > leftIndex) {
                int midIndex = (leftIndex + rightIndex) / 2;

                DivideAndConquer(leftIndex, midIndex);
                DivideAndConquer(midIndex + 1, rightIndex);

                Merge(leftIndex, midIndex + 1, rightIndex);
            }
        }

        private void Merge(int leftIndex, int midIndex, int rightIndex) {
            var count = rightIndex - leftIndex + 1;
            var leftEndIndex = midIndex - 1;
            var sortedSubList = new T[list.Count];
            var sortedListPos = leftIndex;

            while (leftIndex <= leftEndIndex && midIndex <= rightIndex) {
                if (list[leftIndex].CompareTo(list[midIndex]) < 0) {
                    sortedSubList[sortedListPos++] = list[leftIndex++];
                } else {
                    sortedSubList[sortedListPos++] = list[midIndex++];
                }
            }

            while (leftIndex <= leftEndIndex) {
                sortedSubList[sortedListPos++] = list[leftIndex++];
            }

            while (midIndex <= rightIndex) {
                sortedSubList[sortedListPos++] = list[midIndex++];
            }

            for (int k = 0; k < count; k++) {
                list[rightIndex] = sortedSubList[rightIndex];
                rightIndex--;
            }
        }
    }
}
