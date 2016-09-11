using System;
using Xunit;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class SieveOfEratosthenesTests {
        [Fact]
        public void PrimeTest() {
            var expected = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127 };
            var result = SieveOfEratosthenes.ListPrimes(128);

            Assert.Equal(expected, result);
        }
    }
}
