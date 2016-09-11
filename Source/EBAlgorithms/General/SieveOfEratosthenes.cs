using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBAlgorithms {
    public class SieveOfEratosthenes {
        /// <summary>
        /// Returns a list of primes numbers up to the given max.
        /// </summary>
        public static List<int> ListPrimes(int max) {
            var primes = new List<int>();
            var numbers = FindPrimes(max);

            for (var i = 0; i < max; i++) {
                if (numbers[i]) {
                    primes.Add(i);
                }
            }

            return primes;
        }

        /// <summary>
        /// Using the Sieve of Eratosthenes, returns a boolean array where 
        /// prime indecies are set to true and composites are set to false.
        /// </summary>
        public static bool[] FindPrimes(int max) {
            var primes = new bool[max + 1];

            // Initially all numbers set to true above 2.
            for (var i = 2; i < primes.Length; i++) {
                primes[i] = true;
            }

            var prime = 2;

            while (prime <= Math.Sqrt(max)) {
                // Mark remaining multiples of the current prime as false.
                for (var i = prime * prime; i < primes.Length; i += prime) {
                    primes[i] = false;
                }

                // Move up to the next prime number.
                do {
                    prime++;
                } while (prime < primes.Length && !primes[prime]);
            }

            return primes;
        }
    }
}
