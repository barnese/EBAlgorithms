using System;
using System.Numerics;

namespace EBAlgorithms {
    public class LucasLehmerTest {
        /// <summary>
        /// Implements the Lucas-Lehmer Test to check if 2^p-1 is prime.
        /// 
        /// In mathematical speak: For p an odd prime, the Mersenne number 2^p-1 is prime 
        /// if and only if 2^p-1 divides S(p-1) where S(n+1) = S(n)^2-2, and S(1) = 4.
        /// </summary>
        /// <returns>True if prime, false if composite.</returns>
        public static bool IsPrime(int p) {
            if (p < 2)
                return false;

            if (p == 2)
                return true;

            BigInteger s = 4;
            BigInteger m = BigInteger.Pow(2, p) - 1;

            for (var i = 3; i <= p; i++) {
                s = ((s * s) - 2) % m;
            }

            if (s == 0) {
                return true;
            }

            return false;
        }
    }
}
