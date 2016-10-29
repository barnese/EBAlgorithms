using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBAlgorithms {
    public class PrimeNumbers {
        /// <summary>
        /// Determines if the given integer is prime.
        /// </summary>
        public static bool IsPrime(int number) {
            // Base case: two is prime.
            if (number == 2) {
                return true;
            }

            // One and even numbers greater than two are not prime.
            if (number == 1 || (number & 1) == 0) {
                return false;
            }

            for (int i = 3; i <= Math.Sqrt(number); i += 2) {
                // If the number is evenly divisible by i, it is not prime.
                if (number % i == 0) {
                    return false;
                }
            }

            return true;
        }
    }
}
