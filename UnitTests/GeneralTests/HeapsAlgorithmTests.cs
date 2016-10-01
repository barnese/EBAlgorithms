using System;
using Xunit;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class HeapsAlgorithmTests {
        [Fact]
        public void FindPermutationsTest() {
            var input = new List<int> { 1, 2, 3 };

            var expected = new List<List<int>> {
                new List<int> { 1, 2, 3 },
                new List<int> { 2, 1, 3 },
                new List<int> { 3, 1, 2 },
                new List<int> { 1, 3, 2 },
                new List<int> { 2, 3, 1 },
                new List<int> { 3, 2, 1 }
            };

            var result = HeapsAlgorithm.FindPermutations(input);

            Assert.Equal(expected, result);
        }
    }
}
