using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBAlgorithms {
    public class EditDistance {
        /// <summary>
        /// Determines the number of differences between two given strings 
        /// using the Levenshtein Distance algorithm.
        /// </summary>
        public static int FindLevenshteinDistance(string s, string t) {
            return FindLevenshteinDistance(s, s.Length, t, t.Length);
        }

        /// <summary>
        /// Recursive Levenshtein algorithm based on https://en.wikipedia.org/wiki/Levenshtein_distance
        /// </summary>
        /// <remarks>This algorithm is ridiculously slow for strings exceeding ten characters!</remarks>
        private static int FindLevenshteinDistance(string s, int sLength, string t, int tLength) {
            var cost = 0;

            if (sLength == 0) {
                return tLength;
            }

            if (tLength == 0) {
                return sLength;
            }

            if (s[sLength - 1] == t[tLength - 1]) {
                cost = 0;
            } else {
                cost = 1;
            }

            var characterDeletedFromS = FindLevenshteinDistance(s, sLength - 1, t, tLength) + 1;
            var characterDeletedFromT = FindLevenshteinDistance(s, sLength, t, tLength - 1) + 1;
            var characterDeletedFromBoth = FindLevenshteinDistance(s, sLength - 1, t, tLength - 1) + cost;

            return MathHelpers.Min(characterDeletedFromS, characterDeletedFromT, characterDeletedFromBoth);
        }

        public static int FindWagnerFischerDistance(string s, string t) {
            var size = Math.Max(s.Length, t.Length) + 1;
            var matrix = new int[size, size];

            for (var i = 0; i <= s.Length; i++) {
                matrix[0, i] = i;
            }

            for (var j = 0; j <= t.Length; j++) {
                matrix[j, 0] = j;
            }

            for (var j = 1; j <= t.Length; j++) {
                for (var i = 1; i <= s.Length; i++) {
                    var cost = 1;

                    if (s[i - 1] == t[j - 1]) {
                        cost = 0;
                    }

                    matrix[i, j] = MathHelpers.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1, matrix[i - 1, j - 1] + cost);
                }
            }

            // For debugging the matrix...
            for (var i = 0; i < size; i++) {
                for (var j = 0; j < size; j++) {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }

            return matrix[s.Length, t.Length];
        }
    }
}
