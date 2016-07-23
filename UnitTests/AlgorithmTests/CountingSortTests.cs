using System;
using Xunit;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    public class CountingSortTests {

        [Fact]
        public void CountingSort_Integers() {
            var list = TestData.Numbers;

            list.CountingSort();

            Assert.True(list.IsSorted());
        }

        [Fact]
        public void CountingSort_Strings() {
            var list = TestData.Words;

            list.CountingSort();

            Assert.True(list.IsSorted());
        }
    }
}
