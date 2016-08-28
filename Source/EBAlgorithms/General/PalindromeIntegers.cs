using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace EBAlgorithms {
    public class PalindromeIntegers {
        /// <summary>
        /// Checks a list of sample integers.
        /// </summary>
        public static void RunTest() {
            var numbers = new int[] { 197, 254, 342, 765, 987 };
            foreach (var number in numbers) {
                Console.WriteLine("Finding palindrome for {0}:", number);
                SumToPalindrome(number);
            }
        }
        
        /// <summary>
        /// Recursively checks if the sum of an integer and its reverse is a palindrome.
        /// </summary>
        public static void SumToPalindrome(BigInteger number, Int64 iteration = 1) {
            BigInteger reversed = Reverse(number);
            BigInteger sum = number + reversed;

            Console.WriteLine("{0}. {1} + {2} = {3}", iteration, number, reversed, sum);

            if (!IsPalindrome(sum)) {
                SumToPalindrome(sum, ++iteration);
            }
        }

        private static BigInteger Reverse(BigInteger number) {
            var n = number.ToString();
            var reversed = "";

            for (var i = n.Length - 1; i >= 0; i--) {
                reversed += n[i];
            }

            return BigInteger.Parse(reversed);
        }

        private static bool IsPalindrome(BigInteger number) {
            var n = number.ToString();

            for (var i = 0; i < n.Length / 2; i++) {
                if (n[i] != n[n.Length - 1 - i]) {
                    return false;
                }
            }

            return true;
        }
    }
}
