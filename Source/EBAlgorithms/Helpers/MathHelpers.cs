using System;

namespace EBAlgorithms {
    public class MathHelpers {
        /// <summary>
        /// Finds the closest prime number that is greater than the given number.
        /// </summary>
        public static int FindClosestPrime(int number) {
            for (var i = number; ; i++) {
                if (IsPrime(i)) {
                    return i;
                }
            }
        }

        /// <summary>
        /// Determines the number of digits for the given integer.
        /// </summary>
        public static int GetIntLength(int number) {
            return (int)Math.Log10((double)number) + 1;
        }

        /// <summary>
        /// Determines if the given number is a palindrome.
        /// </summary>
        public static bool IsPalindrome(int number) {
            var n = number.ToString();

            for (var i = 0; i < n.Length / 2; i++) {
                if (n[i] != n[n.Length - 1 - i]) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines if a number is prime.
        /// </summary>
        public static bool IsPrime(int number) {
            if (number == 2) return true;
            if (number == 3) return true;
            if (number % 2 == 0) return false;
            if (number % 3 == 0) return false;

            var i = 5;
            var w = 2;

            while (i * i <= number) {
                if (number % i == 0)
                    return false;

                i += w;
                w = 6 - w;
            }

            return true;
        }

        /// <summary>
        /// Returns the minimum of three integers.
        /// </summary>
        public static int Min(int a, int b, int c) {
            return Math.Min(a, Math.Min(b, c));
        }

        /// <summary>
        /// Reverses an integer.
        /// </summary>
        public static int Reverse(int number) {
            var n = number.ToString();
            var reversed = "";

            for (var i = n.Length - 1; i >= 0; i--) {
                reversed += n[i];
            }

            return int.Parse(reversed);
        }
    }
}
