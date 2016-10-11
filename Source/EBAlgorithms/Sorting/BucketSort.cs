using System;
using System.Collections.Generic;

namespace EBAlgorithms {
    /// <summary>
    /// Sorts a list of floats using a bucket sort algorithm. 
    /// </summary>
    public class BucketSort {
        public static void Sort(List<float> list) {
            if (list.Count == 0) {
                return;
            }

            var buckets = new List<List<float>>();

            for (int i = 0; i < list.Count; i++) {
                buckets.Add(new List<float>());
            }

            for (int i = 0; i < list.Count; i++) {
                int bucketIndex = (int)(list.Count * list[i]);
                buckets[bucketIndex].Add(list[i]);
            }

            for (int i = 0; i < list.Count; i++) {
                buckets[i].Sort();
            }

            var listIndex = 0;

            for (int i = 0; i < list.Count; i++) {
                for (int j = 0; j < buckets[i].Count; j++) {
                    list[listIndex] = buckets[i][j];
                    listIndex++;
                }
            }
        }
    }
}
