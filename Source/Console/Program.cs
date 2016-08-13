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
            //CatalanNumbersTest();
            TestLucasLehmer();
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

        public static void CatalanNumbersTest() {
            for (var i = 0; i < 15; i++) {
                Console.Write("{0} ", CatalanNumbers.GetCatalan(i));
            }

            Console.WriteLine();
        }

        public static void TestLucasLehmer() {
            for (var i = 0; i < 10000; i++) {
                if (LucasLehmerTest.IsPrime(i)) {
                    Console.Write("{0} ", i);
                }
            }

            Console.WriteLine();
        }
    }
}
