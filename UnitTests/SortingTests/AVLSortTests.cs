using System;
using Xunit;
using EBAlgorithms;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {

    public class AVLSortTests {

        [Fact]
        public void TestSortingIntegers() {
            var numbers = new List<int>(TestData.Numbers);

            numbers.AVLSort();

            Assert.True(numbers.IsSorted());
        }
    }
}
