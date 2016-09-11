using System;
using Xunit;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class LucasLehmerTests {
        [Fact]
        public void MersennePrimeTest() {
            var expected = new int[] { 2, 3, 5, 7, 13, 17, 19, 31, 61, 89, 107, 127 };
            var result = new List<int>();

            for (var i = 0; i < 256; i++) {
                if (LucasLehmerTest.IsPrime(i)) {
                    result.Add(i);
                }
            }

            Assert.Equal(expected, result);
        }
    }
}
