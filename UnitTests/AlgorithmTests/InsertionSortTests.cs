using System;
using Xunit;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    public class InsertionSortTests {

        [Fact]
        public void InsertionSort_Integers() {
            var list = TestData.Numbers;

            list.InsertionSort();

            Assert.True(list.IsSorted());
        }

        [Fact]
        public void InsertionSort_Strings() {
            var list = TestData.Words;

            list.InsertionSort();

            Assert.True(list.IsSorted());
        }
    }
}
