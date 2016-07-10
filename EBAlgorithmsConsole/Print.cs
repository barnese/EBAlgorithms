using System;
using System.Collections.Generic;
using EBAlgorithms;

namespace EBAlgorithmsConsole {
    /// <summary>
    /// Print helpers.
    /// </summary>
    public class Print<T> where T : IComparable {

        public static void List(List<T> list) {
            var joinedList = String.Join(", ", list);
            Console.WriteLine(joinedList);
        }

        public static void IsListSorted(List<T> list) {
            Console.WriteLine("Is list sorted? {0}", InsertionSort<T>.IsSorted(list));
        }
    }
}
