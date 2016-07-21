using System;
using EBAlgorithms;
using EBAlgorithms.DataStructures;

namespace EBAlgorithmsConsole {
    public class Program {
        public static void Main(string[] args) {
            // var comparer = new CompareSortAlgorithms();
            // comparer.CompareAndPrintOutput();

            int[] numbers = { 41, 20, 65, 11, 29, 50, 26, 23, 55 };

            var tree = new AVLTree<int>(numbers);

            //Console.WriteLine(tree.ToString());

            tree.TraverseInOrder((n) => {
                Console.Write("{0} ", n.key);
            });

            Console.WriteLine("\nCount = {0}", tree.Count);
            Console.WriteLine("Height = {0}", tree.Height);
            Console.WriteLine("Min key = {0}", tree.MinKey);
            Console.WriteLine("Contains {0}? {1}", numbers[0], tree.ContainsKey(numbers[0]));

            //tree.Delete(70);

            //tree.TraverseInOrder((k) => {
            //    Console.Write("{0} ", k);
            //});

            //Console.WriteLine();
        }
    }
}
