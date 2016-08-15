using System.Collections.Generic;
using System.Text;

namespace EBAlgorithms {
    public static class StringExtensions {
        /// <summary>
        /// Finds all permutations of the current string.
        /// </summary>
        /// <returns>A list of all permutations.</returns>
        public static List<string> FindPermutations(this string str) {
            var permutations = new List<string>();
            Permutate(ref str, str.Length, permutations);
            return permutations;
        }

        private static void Permutate(ref string str, int n, List<string> permutations) {
            if (n == 1) {
                permutations.Add(str);
            } else {
                for (var i = 0; i < n; i++) {
                    Permutate(ref str, n - 1, permutations);

                    if (n % 2 == 1) {
                        str = str.Swap(0, n - 1);
                    } else {
                        str = str.Swap(i, n - 1);
                    }
                }
            }
        }

        /// <summary>
        /// Determines if the current string is a palindrome.
        /// </summary>
        public static bool IsPalindrome(this string str) {
            int mid = str.Length / 2;

            for (var i = 0; i < mid; i++) {
                if (str[i] != str[str.Length - i - 1]) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Swaps the character at index i with the character at index j.
        /// </summary>
        public static string Swap(this string str, int i, int j) {
            StringBuilder sb = new StringBuilder(str);

            var temp = sb[i];
            sb[i] = sb[j];
            sb[j] = temp;

            return sb.ToString();
        }
    }
}
