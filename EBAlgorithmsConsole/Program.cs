using System;
using System.Collections.Generic;
using EBAlgorithms;
using EBAlgorithms.DataStructures;

namespace EBAlgorithmsConsole {

    //delegate void TraversalDelegate(int key);

    // This console program is merely a playground for testing purposes.
    class Program {
        static void Main(string[] args) {
            //var comparer = new CompareSortAlgorithms();
            //comparer.CompareAndPrintOutput();

            int[] numbers = { 50, 40, 70, 60, 80 };

            var tree = new BinarySearchTree<int>();

            foreach (int number in numbers) {
                tree.Add(number);
            }

            tree.TraverseInOrder((k) => {
                Console.Write("{0} ", k);
            });

            Console.WriteLine("\nCount = {0}", tree.Count);

            int key = 43;
            Console.WriteLine("Contains {0}? {1}", key, tree.ContainsKey(key));
            Console.WriteLine("Height = {0}", tree.Height);
            Console.WriteLine("Min key = {0}", tree.MinKey);

            tree.Delete(70);

            tree.TraverseInOrder((k) => {
                Console.Write("{0} ", k);
            });

            Console.WriteLine();
        }
    }
}
