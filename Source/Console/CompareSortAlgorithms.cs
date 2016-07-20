using System;
using System.Collections.Generic;
using EBAlgorithms;

namespace EBAlgorithmsConsole {
    public class CompareSortAlgorithms {

        public void CompareAndPrintOutput() {
            var numberOfValues = 10000;
            var originalList = GetRandomIntList(numberOfValues, -10000, 10000);

            var list = CopyOriginalList(originalList);

            Console.WriteLine("Sort list contains {0} values.", numberOfValues);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            list.InsertionSort();

            watch.Stop();
            Console.WriteLine("Insertion sort runtime: {0} ms", watch.ElapsedMilliseconds);

            watch.Reset();
            list = CopyOriginalList(originalList);
            watch.Start();

            list.MergeSort();

            watch.Stop();
            Console.WriteLine("Merge sort runtime: {0} ms", watch.ElapsedMilliseconds);

            watch.Reset();
            list = CopyOriginalList(originalList);
            watch.Start();

            list.HeapSort();

            watch.Stop();
            Console.WriteLine("Heap sort runtime: {0} ms", watch.ElapsedMilliseconds);
        }

        private List<int> CopyOriginalList(List<int> originalList) {
            var list = new List<int>(originalList.Count);
            originalList.ForEach(item => list.Add(item));
            return list;
        }

        private List<int> GetRandomIntList(int size, int minValue, int maxValue) {
            var list = new List<int>(size);
            var random = new Random(DateTime.Now.Millisecond);

            for (var i = 0; i < size; i++) {
                list.Add(random.Next(minValue, maxValue));
            }

            return list;
        }

    }
}
