using System;
using System.Collections.Generic;
using EBAlgorithms;

namespace EBAlgorithmsConsole {
    class Program {
        private static string programName = System.AppDomain.CurrentDomain.FriendlyName;

        static void Main(string[] args) {
            // This console program is merely a playground for testing purposes.
            //try {
                //DocumentDistanceRunner(args);
                //InsertionSort();
                MergeSort();

            //} catch (Exception exception) {
            //    Console.WriteLine(exception.Message);
            //}
        }

        /// <summary>
        /// Runs the document distance algorithm.
        /// </summary>
        /// <example>
        /// .\EBAlgorithmsConsole.exe distance ..\..\Data\DistanceData1.txt ..\..\Data\DistanceData2.txt
        /// </example>
        static void DocumentDistanceRunner(string[] args) {
            if (args.Length != 3) {
                Console.WriteLine("Usage: {0} distance filename1 filename2", programName);
                return;
            }

            var documentDistanceFinder = new DocumentDistanceFinder();

            var distance = documentDistanceFinder.FindDistance(args[1], args[2]);

            Console.WriteLine("The distance is {0} (radians)", distance);

            var ratio = distance / (Math.PI / 2);

            Console.WriteLine("Difference ratio is {0:N2}", ratio);
        }

        static void InsertionSort() {
            var list = new List<int> { 5, 2, 4, 6, 1, 3 };
            var sortedList = InsertionSort<int>.Sort(list);

            Print<int>.List(sortedList);
            Print<int>.IsListSorted(sortedList);
        }
        
        static void MergeSort() {
            //var list = new List<int> { 1, 99, 4, 23, 89, 54, 55, 29, 20, 67, 74, 9, 3, 88, 61, 40, 92, 30, 1, 72 };
            //var sortedList = MergeSort<int>.Sort(list);
            //Print<int>.List(sortedList);
            //Print<int>.IsListSorted(sortedList);

            var list = new List<string> { "zebra", "cat", "walrus", "bird", "bobcat", "bear", "snake", "elephant", "giraffe" };
            var sortedList = MergeSort<string>.Sort(list);

            Print<string>.List(sortedList);
            Print<string>.IsListSorted(sortedList);
        }
    }
}
