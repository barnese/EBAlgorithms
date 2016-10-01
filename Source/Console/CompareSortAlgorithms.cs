using System;
using System.Collections.Generic;
using EBAlgorithms;

namespace EBAlgorithmsConsole {
    public class CompareSortAlgorithms {

        public void CompareAndPrintOutput() {
            var numberOfValues = 10000;
            var list = GetRandomIntList(numberOfValues, 0, numberOfValues);

            Console.WriteLine("Sort list contains {0} random integers.", numberOfValues);

            RunTest("AVL Sort", list);
            RunTest("Counting Sort", list);
            RunTest("Heap Sort", list);
            RunTest("Insert Sort", list);
            RunTest("Merge Sort", list);
            RunTest("Quick Sort", list);
        }

        private void RunTest(string algorithm, List<int> list) {
            var listCopy = CopyOriginalList(list);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            switch (algorithm) {
                case "AVL Sort":
                    listCopy.AVLSort();
                    break;
                case "Counting Sort":
                    listCopy.CountingSort();
                    break;
                case "Heap Sort":
                    listCopy.HeapSort();
                    break;
                case "Insert Sort":
                    listCopy.InsertionSort();
                    break;
                case "Merge Sort":
                    listCopy.MergeSort();
                    break;
                case "Quick Sort":
                    listCopy.QuickSort();
                    break;
                default:
                    break;
            }

            watch.Stop();

            if (!listCopy.IsSorted()) {
                Console.WriteLine("{0} is not sorted!", algorithm);
            }

            Console.WriteLine("{0} runtime: {1} ms", algorithm, watch.ElapsedMilliseconds);
        }

        private List<int> CopyOriginalList(List<int> originalList) {
            var list = new List<int>(originalList.Count);
            originalList.ForEach(item => list.Add(item));
            return list;
        }

        private List<int> GetRandomIntList(int size, int minValue, int maxValue) {
            var list = new List<int>(size);
            var random = new Random(DateTime.Now.Millisecond);

            int step = (int)Math.Ceiling((double)(maxValue - minValue) / size);

            for (var i = 0; i < size; i++) {
                list.Add(i * step);
            }

            // Randomly swap values.
            for (var i = 0; i < size; i++) {
                var randomIndex = random.Next(0, size);
                list.Swap(i, randomIndex);
            }

            return list;
        }
    }
}
