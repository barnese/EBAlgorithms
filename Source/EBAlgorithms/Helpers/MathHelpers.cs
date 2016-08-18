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
    }
}
