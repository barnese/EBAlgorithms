using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBAlgorithms {
    /// <summary>
    /// Catalan numbers:
    /// C[0] = 1
    /// C[n+1] = Sum(C[i] * C[n-1]) from i = 0 to n for n >= 0.
    /// </summary>
    public class CatalanNumbers {
        /// <summary>
        /// Gets the nth Catalan number.
        /// </summary>
        public static int GetCatalan(int n) {
            int catalan = 0;

            if (n <= 1) {
                return 1;
            }

            for (var i = 0; i < n; i++) {
                catalan += GetCatalan(i) * GetCatalan(n - i - 1);
            }

            return catalan;
        }

        /// <summary>
        /// Gets an array of Catalan numbers up to n.
        /// </summary>
        public static int[] GetCatalanNumbers(int n) {
            var catalanNumbers = new int[n];

            for (var i = 0; i < n; i++) {
                catalanNumbers[i] = GetCatalan(i);
            }

            return catalanNumbers;
        }
    }
}
