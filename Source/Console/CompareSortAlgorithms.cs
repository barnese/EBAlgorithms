using System;
using System.Collections.Generic;
using EBAlgorithms;

namespace EBAlgorithmsConsole {
    public class CompareSortAlgorithms {

        public void CompareAndPrintOutput() {
            var numberOfValues = 10000;
            var list = GetRandomIntList(numberOfValues, 0, numberOfValues, true);

            Console.WriteLine("Sort list contains {0} random integers.", numberOfValues);

            RunTest("AVL Sort", list);
            RunTest("Counting Sort", list);
            RunTest("Heap Sort", list);
            RunTest("Insert Sort", list);
            RunTest("Merge Sort", list);
        }
         
        private void RunTest(string algorithm, List<int> list) {
            var listCopy = CopyOriginalList(list);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            switch (algorithm) {
                case "Insert Sort":
                    listCopy.InsertionSort();
                    break;
                case "Merge Sort":
                    listCopy.MergeSort();
                    break;
                case "Heap Sort":
                    listCopy.HeapSort();
                    break;
                case "AVL Sort":
                    listCopy.AVLSort();
                    break;
                case "Counting Sort":
                    listCopy.CountingSort();
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

        private List<int> GetRandomIntList(int size, int minValue, int maxValue, bool uniqueValues) {
            var list = new List<int>(size);
            var random = new Random(DateTime.Now.Millisecond);

            for (var i = 0; i < size; i++) {
                int randomInt;
                do {
                    randomInt = random.Next(minValue, maxValue);
                } while (uniqueValues && list.Contains(randomInt));

                list.Add(randomInt);
            }

            return list;
        }

    }
}
