using System;
using Xunit;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class StringExtensionTests {
        [Fact]
        public void StringExtensions_TestSwap() {
            var str = "cat";
            var expected = "tac";
            var result = str.Swap(0, 2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void StringExtensions_TestPermutations() {
            var str = "cat";
            var expected = new List<string> { "cat", "act", "tca", "cta", "atc", "tac" };
            var result = str.FindPermutations();
            Assert.Equal(expected, result);
        }

        [Fact] 
        public void StringExtensions_TestIsPalindrome() {
            var palindromes = new List<string> { "lol", "abcdefedcba", "elle" };
            var nonPalindromes = new List<string> { "abc", "hi", "asdf" };

            foreach (var palindrome in palindromes) {
                Assert.True(palindrome.IsPalindrome());
            }

            foreach (var nonPalindrome in nonPalindromes) {
                Assert.False(nonPalindrome.IsPalindrome());
            }
        }
    }
}
