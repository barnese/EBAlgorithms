using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAlgorithms {

    public class MergeSort<T> : BaseSort<T> where T : IComparable {

        public static List<T> Sort(List<T> list) {
            return DivideAndConquer(list);
        }

        private static List<T> DivideAndConquer(List<T> list) {
            if (list.Count > 0) {
                int midPoint = list.Count / 2;

                var leftList = list.GetRange(0, midPoint);
                var rightList = list.GetRange(midPoint, midPoint);
                
                if (midPoint > 1) {
                    leftList = DivideAndConquer(leftList);
                    rightList = DivideAndConquer(rightList);
                }

                return Merge(leftList, rightList);
            }

            return new List<T>(0);
        }

        private static List<T> Merge(List<T> leftList, List<T> rightList) {
            int count = leftList.Count + rightList.Count;
            var sortedList = new List<T>(count);

            // Merge the two lists using "two finger" algorithm, i and j are the fingers.
            int i = 0;
            int j = 0;

            for (int k = 0; k < count; k++) {
                if (j >= rightList.Count && i < leftList.Count) {
                    sortedList.Add(leftList[i]);
                    i++;
                } else if (j < rightList.Count && i >= leftList.Count) {
                    sortedList.Add(rightList[j]);
                    j++;
                } else if (leftList[i].CompareTo(rightList[j]) < 0) { // leftList[i] < rightList[j]
                    sortedList.Add(leftList[i]);
                    i++;
                } else {
                    sortedList.Add(rightList[j]);
                    j++;
                }
            }

            return sortedList;
        }
    }
}
