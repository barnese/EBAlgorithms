using System;
using Xunit;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class CatalanNumbersTests {
        [Fact]
        public void CatalanNumbersTest() {
            var expected = new int[] { 1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012, 742900, 2674440 };
            var result = CatalanNumbers.GetCatalanNumbers(15);

            Assert.Equal(expected, result);
        }
    }
}
