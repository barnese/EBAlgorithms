using System;
using EBAlgorithms.DataStructures;
using System.Collections.Generic;

namespace EBAlgorithms {
    public class KarpRabin {
        /// <summary>
        /// Searches the text string for the given pattern string using the Karp-Rabin algorithm.
        /// </summary>
        /// <remarks>
        /// Referenced: http://www.geeksforgeeks.org/searching-for-patterns-set-3-rabin-karp-algorithm/
        /// </remarks>
        /// <returns>
        /// List of indices of locations in the text where the pattern was found.
        /// Returns empty list if the pattern was not found.
        /// </returns>
        public static List<int> Search(string text, string pattern) {
            var matches = new List<int>();

            var charSetSize = 256;
            var primeNumber = 101;

            var power = (int)(Math.Pow(charSetSize, pattern.Length - 1) % primeNumber);

            var patternHash = 0;
            var textHash = 0;

            // Prepare the hashes for the first window of comparison.
            for (var i = 0; i < pattern.Length; i++) {
                patternHash = (charSetSize * patternHash + pattern[i]) % primeNumber;
                textHash = (charSetSize * textHash + text[i]) % primeNumber;
            }

            // Loop through each character in the original text and compare against the pattern's hash.
            for (var i = 0; i <= text.Length - pattern.Length; i++) {
                if (textHash == patternHash) {
                    var found = true;

                    // Verify a match was really found by checking all characters.
                    for (var j = 0; j < pattern.Length; j++) {
                        if (text[i + j] != pattern[j]) {
                            found = false;
                            break;
                        }
                    }

                    if (found) {
                        matches.Add(i);
                    }
                }

                if (i < text.Length - pattern.Length) {
                    textHash = (charSetSize * (textHash - text[i] * power) + text[i + pattern.Length]) % primeNumber;

                    // Make sure negative hash to made positive.
                    if (textHash < 0) {
                        textHash += primeNumber;
                    }
                }
            }

            return matches;
        }
    }
}
