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
            CompareSortAlgorithms();
            //HashMapTests();
        }
        
        public static void CompareSortAlgorithms() {
            var comparer = new CompareSortAlgorithms();
            comparer.CompareAndPrintOutput();
        }

        public static void HashMapTests() {
            Console.OutputEncoding = Encoding.Unicode;

            var words = FileHelpers.SplitFileIntoWords("LoremIpsum.txt");

            var size = 131071; // 2^17-1 prime
            var hashmap = new HashMap<string, int>(size, HashFunction.Universal);

            foreach (var word in words) {
                var w = word.ToLower();             
                if (hashmap.ContainsKey(w)) {
                    hashmap[w]++;
                } else {
                    hashmap.Put(w, 1);
                }
            }

            var hashCodes = new List<int>();

            foreach (var entry in hashmap) {
                var hashCode = hashmap.GetHashCode(entry.Key);

                if (!hashCodes.Contains(hashmap.GetHashCode(entry.Key))) {
                    hashCodes.Add(hashCode);
                }
            }

            Console.WriteLine("\nWord count = {0}", words.Length);
            Console.WriteLine("Unique word count = {0}", hashmap.Count);
            Console.WriteLine("Unique hash codes = {0}", hashCodes.Count);
        }
    }
}
