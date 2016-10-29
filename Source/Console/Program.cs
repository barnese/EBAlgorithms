using System;
using EBAlgorithms;
using EBAlgorithms.DataStructures;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Numerics;

namespace EBAlgorithmsConsole {
    public class Program {
        public static void Main(string[] args) {
            //CompareSortAlgorithms();

            var number = 40667873;
            var result = PrimeNumbers.IsPrime(number) ? "prime" : "not prime";
            Console.WriteLine("{0} is {1}", number, result);
        }

        public static void CompareSortAlgorithms() {
            var comparer = new CompareSortAlgorithms();
            comparer.CompareAndPrintOutput();
        }
    }
}
