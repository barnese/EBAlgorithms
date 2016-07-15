using System;
using System.Collections.Generic;
using EBAlgorithms;
using System.IO;
using System.Text;

namespace EBAlgorithmsConsole {

    // This console program is merely a playground for testing purposes.
    class Program {
        static void Main(string[] args) {
            CompareSortAlgorithms();
        }

        static void CompareSortAlgorithms() {
            var numberOfValues = 10000;
            var list = GetRandomIntList(numberOfValues, -10000, 10000);

            var startTime = DateTime.Now;

            list.InsertionSort();

            var insertionSortRunTime = DateTime.Now - startTime;

            startTime = DateTime.Now;

            list.MergeSort();

            var mergeSortRunTime = DateTime.Now - startTime;

            startTime = DateTime.Now;

            list.HeapSort();

            var heapSortRunTime = DateTime.Now - startTime;

            Console.WriteLine("Sort list contains {0} values.", numberOfValues);
            Console.WriteLine("Insertion sort runtime: {0} ms", insertionSortRunTime.TotalMilliseconds);
            Console.WriteLine("Merge sort runtime: {0} ms", mergeSortRunTime.TotalMilliseconds);
            Console.WriteLine("Heap sort runtime: {0} ms", heapSortRunTime.TotalMilliseconds);
        }

        static List<int> GetRandomIntList(int size, int minValue, int maxValue) {
            var list = new List<int>(size);
            var random = new Random(DateTime.Now.Millisecond);

            for (var i = 0; i < size; i++) {
                list.Add(random.Next(minValue, maxValue));
            }

            return list;
        }
    }
}
