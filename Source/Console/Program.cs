using System;
using EBAlgorithms;
using EBAlgorithms.DataStructures;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace EBAlgorithmsConsole {
    public class Program {
        public static void Main(string[] args) {
            //CompareSortAlgorithms();
            //HashMapTests();

            var hashmap = new HashMapOpenAddressing<string, int>();
            hashmap.Put("one", 1);
            hashmap.Put("two", 2);
            hashmap.Put("three", 3);

            Console.WriteLine("Count = {0}", hashmap.Count);
            Console.WriteLine("two = {0}", hashmap["two"]);

            hashmap.Delete("one");
            Console.WriteLine("Deleted one. Count = {0}", hashmap.Count);
        }

        public static void CompareSortAlgorithms() {
            var comparer = new CompareSortAlgorithms();
            comparer.CompareAndPrintOutput();
        }

        public static void HashMapTests() {
            Console.OutputEncoding = Encoding.Unicode;

            var words = FileHelpers.SplitFileIntoWords("LoremIpsum.txt");

            var hashmap = new HashMap<string, int>(words.Length);

            foreach (var word in words) {
                var w = word.ToLower();             
                if (hashmap.ContainsKey(w)) {
                    hashmap[w]++;
                } else {
                    hashmap.Put(w, 1);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Total words  = {0}", words.Length);
            Console.WriteLine("Unique words = {0}", hashmap.Count);
        }
    }
}
